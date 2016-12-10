using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using VDS.RDF.Storage;

namespace SemanticFormApp
{
    class rdfreader
    {

       public static object rdfexec(string port, string ds, string query)
        {
            List<object> list = new List<object>();
            // IGraph g = new Graph();

            //UriLoader.Load(g, new Uri("Http://localhost:3030/one/data"));
            //  FusekiConnector fuseki = new FusekiConnector("Http://localhost:3030/one/data");
            FusekiConnector fuseki = new FusekiConnector("Http://localhost:" + port + "/" + ds + "/data");
            try
            {
                // Object result s = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");

                //Object results = g.ExecuteQuery("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                //*Object results = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                Object results = fuseki.Query(query);
                if (results is SparqlResultSet)
                {
                    SparqlResultSet rset = (SparqlResultSet)results;
                    foreach (SparqlResult r in rset)
                    {
                        //do whatever you want with each result
                        //Console.WriteLine(r);
                        list.Add(r);
                    }
                }
                else if (results is IGraph)
                {
                    IGraph resGraph = (IGraph)results;
                    foreach (Triple t in resGraph.Triples)
                    {
                        list.Add(t);
                        //Console.WriteLine(t);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (RdfQueryException queryEx)
            {
                Console.WriteLine(queryEx.Message);
            }
           
            return list;
        }

        public static object rdfexec(string query)
        {
            List<object> list = new List<object>();
            // IGraph g = new Graph();

            //UriLoader.Load(g, new Uri("Http://localhost:3030/one/data"));
            //  FusekiConnector fuseki = new FusekiConnector("Http://localhost:3030/one/data");
            FusekiConnector fuseki = new FusekiConnector("Http://localhost:3030/one/data");
            try
            {
                // Object result s = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");

                //Object results = g.ExecuteQuery("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                //*Object results = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                Object results = fuseki.Query(query);
                if (results is SparqlResultSet)
                {
                    SparqlResultSet rset = (SparqlResultSet)results;
                    foreach (SparqlResult r in rset)
                    {
                        //do whatever you want with each result
                        //Console.WriteLine(r);
                        list.Add(r);
                    }
                }
                else if (results is IGraph)
                {
                    IGraph resGraph = (IGraph)results;
                    foreach (Triple t in resGraph.Triples)
                    {
                        list.Add(t);
                        //Console.WriteLine(t);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (RdfQueryException queryEx)
            {
                Console.WriteLine(queryEx.Message);
            }
           
            return list;
        }
        public static object rdfexec()
        {
            List<object> list = new List<object>();
            // IGraph g = new Graph();

            //UriLoader.Load(g, new Uri("Http://localhost:3030/one/data"));
            //  FusekiConnector fuseki = new FusekiConnector("Http://localhost:3030/one/data");
            FusekiConnector fuseki = new FusekiConnector("Http://localhost:3030/one/data");
            try
            {
                // Object result s = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");

                //Object results = g.ExecuteQuery("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                //*Object results = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                Object results = fuseki.Query("PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> PREFIX owl: <http://www.w3.org/2002/07/owl#> PREFIX rdfs:<http://www.w3.org/2000/01/rdf-schema#> PREFIX xsd: <http://www.w3.org/2001/XMLSchema#> PREFIX vg: <http://www.videogame.com/game#> SELECT ?subject ?object WHERE { ?subject rdfs:subClassOf ?object } ");
                if (results is SparqlResultSet)
                {
                    SparqlResultSet rset = (SparqlResultSet)results;
                    foreach (SparqlResult r in rset)
                    {
                        //do whatever you want with each result
                        //Console.WriteLine(r);
                        list.Add(r);
                    }
                }
                else if (results is IGraph)
                {
                    IGraph resGraph = (IGraph)results;
                    foreach (Triple t in resGraph.Triples)
                    {
                        list.Add(t);
                        //Console.WriteLine(t);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (RdfQueryException queryEx)
            {
                Console.WriteLine(queryEx.Message);
            }
           
            return list;
        }
    }
}
    