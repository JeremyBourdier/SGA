package modelo;

import controlador.ConexionBD;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

/**
 * Clase DAO (Data Access Object) para manejar la autenticación de usuarios.
 * Ofrece un método para verificar las credenciales de los usuarios en la base de datos.
 *
 * @author bourdier
 */
public class LoginDAO {
  
    /**
     * Verifica las credenciales de un usuario.
     * Comprueba en la base de datos si existen un correo electrónico y una contraseña coincidentes.
     *
     * @param Pcorreo El correo electrónico del usuario que intenta iniciar sesión.
     * @param Pcontraseña La contraseña del usuario.
     * @return boolean Retorna 'true' si las credenciales son válidas, 'false' en caso contrario.
     */
  
  public static boolean Autenticacion(String Pcorreo, String Pcontraseña){
    ConexionBD conexion = new ConexionBD();
    Connection con;
    con = (Connection) conexion.conectarBaseDatos();
    PreparedStatement ps;
    ResultSet rs;
    
    String sql="SELECT correo_electronico,contraseña FROM usuarios WHERE correo_electronico=? and contraseña=?";
    try {
      
      ps=con.prepareStatement(sql);
      ps.setString(1, Pcorreo);
      ps.setString(2, Pcontraseña);
      rs=ps.executeQuery();
      
      while(rs.next()){
        con.close();
        return true;
      }
      
    } catch (Exception e) {
      System.out.println("Error al autenticar: "+e);
    }
    return false;
    
  }
  
}

// Ejemplo de uso:
// boolean esValido = LoginDAO.Autenticacion("usuario@example.com", "contraseña123");
// if (esValido) {
//     // Acciones a realizar si el usuario es autenticado correctamente
// } else {
//     // Acciones a realizar si la autenticación falla
// }
