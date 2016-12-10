import org.apache.jena.query.* ;
import org.apache.jena.sparql.engine.http.QueryEngineHTTP ;

public class QueryProcessor {
	
		static void processor(String port, String ds, String queryStr){
		
	    Query query = QueryFactory.create(queryStr);

        // Remote execution.
        QueryExecution qexec = QueryExecutionFactory.sparqlService("http://localhost:"+port+"/"+ds+"/query", query) ;
            // Set the DBpedia specific timeout.
            ((QueryEngineHTTP)qexec).addParam("timeout", "10000") ;

            // Execute.
            ResultSet rs = qexec.execSelect();
            ResultSetFormatter.out(System.out, rs, query);
         }
	
	
	
}
