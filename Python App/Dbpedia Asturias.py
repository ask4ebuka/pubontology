# -*- coding: utf-8 -*-
"""
Created on Fri Dec  9 20:34:19 2016

@author: Home
"""
from SPARQLWrapper import SPARQLWrapper, JSON

sparql = SPARQLWrapper("http://dbpedia.org/sparql")
sparql.setQuery("""
                PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#>
                SELECT ?label
                Where {<http://dbpedia.org/resource/Asturias> rdfs:label ?label}
""")
sparql.setReturnFormat(JSON)
results= sparql.query().convert()

for result in results["results"]["bindings"]:
    print (result ["label"]["value"])
