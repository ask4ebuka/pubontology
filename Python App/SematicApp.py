# -*- coding: utf-8 -*-
"""
Created on Fri Dec  9 20:34:19 2016

@author: Home
"""

import tkinter
from tkinter import messagebox
from SPARQLWrapper import SPARQLWrapper, JSON

top = tkinter.Tk()
def helloCallBack():
    messagebox.showinfo("Hello Python","Hello world")

B= tkinter.Button(top, text ="Hello", command = helloCallBack)
B.pack()
top.mainloop()


sparql = SPARQLWrapper("http://localhost:3030/one")
sparql.setQuery("""
                PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
PREFIX owl: <http://www.w3.org/2002/07/owl#>
PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
SELECT ?subject ?object
WHERE {
  ?subject rdfs:subClassOf ?object 
}
""")
sparql.setReturnFormat(JSON)
results= sparql.query().convert()


for result in results["results"]["bindings"]:
    print (result)
