import requests
import json

#the required first parameter of the 'get' method is the 'url':
def get(url):
    x = requests.get(url)
    #return the response text
    return x.text

def post(url):
    x = requests.post(url)
    #return the response text
    return x.text

def update(url,data,headers):
    x = requests.put(url,data = data,headers = headers)
    #return the response text
    return x.text

def delete(url):
    x = requests.delete(url)
    #return the response text
    return x.text


