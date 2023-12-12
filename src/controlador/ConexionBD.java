package controlador;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Esta clase se encarga de establecer la conexión con la base de datos MySQL.
 * Utiliza JDBC para conectar y manejar la base de datos.
 * 
 * @author bourdier
 */
public class ConexionBD {

    // Variables para la conexión a la base de datos
    private Connection con;
    private String driver = "com.mysql.cj.jdbc.Driver"; 
    private String dbName = "Itla"; 
    private String url = "jdbc:mysql://localhost:3306/" + dbName + "?useSSL=false&serverTimezone=UTC"; 
    private String usuario = "root"; 
    private String clave = "1jsynd0;"; 

    /**
     * Conecta con la base de datos usando el driver JDBC, URL, usuario y clave proporcionados.
     * 
     * @return Un objeto Connection si la conexión es exitosa, de lo contrario null.
     */
    public Connection conectarBaseDatos() {
        try {
            // Carga el driver JDBC
            Class.forName(driver);
            // Establece la conexión con la base de datos
            con = DriverManager.getConnection(url, usuario, clave);
            System.out.println("Conexion exitosa");
        } catch (ClassNotFoundException | SQLException e) {
            // Maneja las posibles excepciones durante la conexión
            System.out.println("Error en la conexion: " + e);
        }
        return con;
    }  
}//Fin de clase ConexionBD
