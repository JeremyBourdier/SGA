package controlador;

/**
 *
 * @author bourdier
 */
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
/**
     * Método principal para probar la conexión con la base de datos.
     * 
     * @param args Argumentos de la línea de comandos, no se utilizan en este método.
     */
public class TestConexion {

    public static void main(String[] args) {
        ConexionBD db = new ConexionBD();
        try {
            Connection conn = db.conectarBaseDatos();
            if (conn != null) {
                Statement stmt = conn.createStatement();
                ResultSet rs = stmt.executeQuery("SELECT * FROM estudiantes");
                while (rs.next()) {                  
                    System.out.println("ID: " + rs.getInt("id") +
                                       ", matricula: " + rs.getInt("matricula") +
                                       ", nombres: " + rs.getString("nombres") +
                                       ", apellidos: " + rs.getString("apellidos") +
                                       ", correo_electronico: " + rs.getString("correo_electronico") +
                                       ", numero_telefono: " + rs.getString("numero_telefono"));
                                      
                }
                rs.close();
                stmt.close();
                conn.close();
            } else {
                System.out.println("No se pudo conectar a la base de datos.");
            }
        } catch (SQLException e) {
            System.out.println("SQLException: " + e.getMessage());
        }
    }
}//Fin de clase TestConexion
