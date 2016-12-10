import org.apache.jena.query.* ;
import org.apache.jena.sparql.engine.http.QueryEngineHTTP ;
public class AppMenu {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String queryStr = "select  * where {?s a ?Class} LIMIT 10";
	QueryProcessor.processor("3030", "one", queryStr);
	}

}
