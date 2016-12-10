
public class ListQuery {
	
	static String query(String subject,String property, String object,String className){
		String queryStr = 
					"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>"
					+"PREFIX owl: <http://www.w3.org/2002/07/owl#>"
					+"PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>"
					+"PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>"
					+"PREFIX vg: <http://www.videogame.com/game#>"
					+"SELECT DISTINCT "
					+"WHERE { ?"+object+" "
					 
					+"?"+ subject+"  a vg:"+className+"."
					+ "?"+subject+"  vg:"+property+" ?"+object 
					+"}";

		
		return queryStr;
	}  

}
