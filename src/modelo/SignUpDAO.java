package modelo;

import controlador.ConexionBD;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 * Clase DAO (Data Access Object) para manejar las operaciones de registro de nuevos usuarios en la base de datos.
 * Ofrece un método para insertar un nuevo usuario en la base de datos.
 *
 * @author bourdier
 */
public class SignUpDAO {
  
      /**
     * Inserta un nuevo usuario en la base de datos.
     * Toma un objeto Usuarios y lo utiliza para agregar un nuevo registro en la tabla de usuarios.
     *
     * @param x Objeto Usuarios que contiene la información del usuario a registrar.
     * @return boolean Retorna 'true' si el usuario es insertado con éxito, 'false' en caso contrario.
     */

  public static boolean InsertarUsuario(Usuarios x){
    ConexionBD conexion = new ConexionBD(); 
    Connection con;
    PreparedStatement ps;
    ResultSet rs;
  
  String sql="INSERT INTO usuarios (nombre_completo,correo_electronico,contraseña) VALUES (?,?,?)";
  
    try {
      con = (Connection) conexion.conectarBaseDatos();
      ps = con.prepareStatement(sql);
      ps.setString(1, x.getNombre_completo());
      ps.setString(2, x.getCorreo_electronico());
      ps.setString(3, x.getContraseña());
      
      ps.execute();
      con.close();
      
      return true;
      
    } catch (SQLException e) {
      System.out.println("Error en el registro de usuario: "+e);
    }
    return false;
    
  }
  
}
// Ejemplo de uso:
// Usuarios nuevoUsuario = new Usuarios();
// nuevoUsuario.setNombre_completo("Juan Pérez");
// nuevoUsuario.setCorreo_electronico("juan.perez@example.com");
// nuevoUsuario.setContraseña("contraseña123");
// boolean registroExitoso = SignUpDAO.InsertarUsuario(nuevoUsuario);
// if (registroExitoso) {
//     // Acciones a realizar si el usuario es registrado con éxito
// } else {
//     // Acciones a realizar si el registro falla
// }