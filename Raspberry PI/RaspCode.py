from requests.models import HTTPError
import HttpRequests
import json
import random
import time
from datetime import datetime
#import RPi.GPIO as gpio

#region VariablesToSend
#Output ----------------------------
q10 = False #Falha
q11 = False #Abrindo
q12 = False #Aberto
q13 = False #Parado
q14 = False #Fechando
q15 = False #Fechado
q16 = False #
q17 = False #
#Output ----------------------------
q00 = False #Motor ON
q01 = False #Motor OFF
q02 = False #Valvula Ok
q03 = False #Valvula Problem
q04 = False #Temp Ok.
q05 = False #Temp Problem.
q06 = False #
q07 = False #
#Other Signals 
idSignal = 1
idDevice = 1
messagemNum = 1
temp = 50
dataDeAtualizacao = '02/02/2020'
#endregion

#region VariablesReceived
#Inputs  ----------------------------
i00 = 0 #Abrir
i01 = 0 #Parar
i02 = 0 #Fechar
i03 = 0 #Emergencia
i04 = 0 #
i05 = 0 #
i06 = 0 #
i07 = 0 #
sensor = 100


#endregion

#region AuxFunctions
def formatData():
    return {
    'idSinal':idSignal,
    'idDeviceInfo': idDevice,
    'q10':q10, #Falha
    'q11':q11, #Abrindo
    'q12':q12, #Aberto
    'q13':q13, #Parado
    'q14':q14, #Fechando
    'q15':q15, #Fechado
    'q16':q16,
    'q17':q17,
    'q00':q00, #Motor ON
    'q01':q01, #Motor OFF
    'q02':q02, #Valvula Ok
    'q03':q03, #Valvula Problem
    'q04':q04, #Temp Ok
    'q05':q05, #Temp Problem
    'q06':q06,
    'q07':q07,
    'messagemNum':messagemNum,
    'temperatura':temp,
    'dataDeAtualizacao':dataDeAtualizacao
    }
def toBool(value):
    if (value == 1):
        return True
    else:
        return False

def checkTemp(_temp): 
    # Temperatura ok
    if(_temp < 40):
        q04 = True
        q05 = False
        return 'Temperatura OK'
    #Temperatura muito alta
    else:
        q04 = False
        q05 = True
        return 'Temperatura muito alta'

#endregion


#region MainProgram
while 1:
    temp = random.randint(21, 50)
    sensor = random.randint(0, 100)
    print("Temperatura da caixa: "+str(temp))
    print(checkTemp(temp))   

    if i03 == False:
        messagemNum = 1
        #Comporta aberta
        if(i00 == 1 and i01 == 0 and i02 == 0 ):
            q00 = False
            q01 = True
            q02 = True
            q03 = False
            q12 = True
            q13 = False
            q15 = False
            messagemNum = 9
        #Sistema Parado
        elif (i00 == 0 and i01 == 1 and i02 == 0 ):
            q00 = False
            q01 = True
            q02 = True
            q03 = False
            q12 = False
            q13 = True
            q15 = False
            messagemNum = 8
        #Comporta Fechada
        elif (i00 == 0 and i01 == 0 and i02 == 1 ):
            q00 = False
            q01 = True
            q02 = True
            q03 = False
            q12 = False
            q13 = False
            q15 = True
            messagemNum = 10   
           # Enchendo caixa
        elif ((i00 == 0 and i01 == 0 and i02 == 0) or sensor < 50 or q04 == True):
            q00 = True
            q01 = False
            q02 = True
            q03 = False
            q12 = False
            q13 = False
            q15 = False
            messagemNum = 5
        # Caixa vazia
        elif ((i00 == 0 and i01 == 0 and i02 == 0) or sensor > 70 or q05 == True):
            q00 = False
            q01 = True
            q02 = True
            q03 = False
            q12 = False
            q13 = False
            q15 = False
            messagemNum = 6     
        # Sistema Parado
        else:
            q00 = False
            q01 = True
            q02 = True
            q03 = False
            q12 = False
            q13 = False
            q15 = False
            messagemNum = 8
         
    #Emergencia Acionado
    else:
        messagemNum = 4
        q00 = False
        q01 = True
        q02 = True
        q03 = False
        q12 = True
        q13 = False
        q15 = False
    
    dataDeAtualizacao = str(datetime.now())
    headers = {"Content-Type": "application/json"}
    data = json.dumps(formatData())    
    HttpRequests.update('http://localhost:5000/api/Sinais', data , headers)
    infosFromDb = json.loads(HttpRequests.get('http://localhost:5000/api/SinaisDeInput'))[0]
    i00 = infosFromDb['i00']
    i01 = infosFromDb['i01']
    i02 = infosFromDb['i02']
    i03 = infosFromDb['i03']
    i04 = infosFromDb['i04']
    i05 = infosFromDb['i05']
    i06 = infosFromDb['i06']
    i07 = infosFromDb['i07']
    print(infosFromDb['idSinal'])
    print(str(infosFromDb))
    time.sleep(0.5)
#endregion





