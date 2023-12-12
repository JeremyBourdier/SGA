package modelo;

import java.sql.Connection;
import controlador.ConexionBD;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import java.sql.SQLException;
import java.sql.PreparedStatement;
/**
 * Clase DAO (Data Access Object) para manejar las operaciones de la base de datos relacionadas con los estudiantes.
 * Ofrece métodos para listar, agregar, actualizar, eliminar y buscar estudiantes en la base de datos.
 * Utiliza JDBC para conectarse y ejecutar consultas SQL.
 *
 * @author bourdier
 */

public class EstudiantesDAO {
  ConexionBD conexion = new ConexionBD(); //Instacia de conexion a la base de datos
  Connection con;
  PreparedStatement ps;
  ResultSet rs;
  
  /**
     * Recupera una lista de todos los estudiantes en la base de datos.
     * 
     * @return Lista de objetos EstudiantesDTO con los datos de los estudiantes.
     */
  public List<EstudiantesDTO> Listar() {
    String sql = "SELECT * FROM estudiantes";
    List<EstudiantesDTO> lista = new ArrayList<>();
    try {
      con = (Connection) conexion.conectarBaseDatos();
      ps = con.prepareStatement(sql);
      rs = ps.executeQuery();
      while (rs.next()) {
        EstudiantesDTO estudiante = new EstudiantesDTO();
        estudiante.setId(rs.getInt(1));
        estudiante.setMatricula(rs.getInt(2));
        estudiante.setNombres(rs.getString(3));
        estudiante.setApellidos(rs.getString(4));
        estudiante.setCorreo_electronico(rs.getString(5));
        estudiante.setNumero_telefono(rs.getString(6));
        lista.add(estudiante);
       
      }
    } catch (SQLException e) {
      System.out.println("Error al listar estudiantes: "+e);
    }
    return lista;
  }
  /**
     * Agrega un nuevo estudiante a la base de datos.
     * 
     * @param estudiante Objeto EstudiantesDTO con la información del estudiante a agregar.
     * @return int Indicador del resultado de la operación (generalmente 1 para éxito y 0 para fallo).
     */
  //Metodo agregar
  public int agregar(EstudiantesDTO estudiante) {
    int r = 0;
    String sql = "INSERT INTO estudiantes (matricula, nombres, apellidos, correo_electronico, numero_telefono) VALUES (?, ?, ?, ?, ?)";
    try {
      con = conexion.conectarBaseDatos(); // Establecer la conexión
      ps = con.prepareStatement(sql); // Preparar el statement

      // Establecer los valores de los parámetros basados en el objeto 'estudiante'
      ps.setInt(1, estudiante.getMatricula());
      ps.setString(2, estudiante.getNombres());
      ps.setString(3, estudiante.getApellidos());
      ps.setString(4, estudiante.getCorreo_electronico());
      ps.setString(5, estudiante.getNumero_telefono());

      r = ps.executeUpdate(); // Ejecutar la inserción

      
      ps.close();
      con.close();
    } catch (SQLException e) {
      System.out.println("Error al agregar estudiante: " + e);
    } finally {
      try {
        if (ps != null) {
          ps.close();
        }
        if (con != null) {
          con.close();
        }
      } catch (SQLException e) {
        System.out.println("Error al cerrar los recursos: " + e);
      }
    }
    return r; // Retorna el resultado de la operación
  }//Fin del metodo agregar
   /**
     * Actualiza la información de un estudiante existente en la base de datos.
     * 
     * @param estudiante Objeto EstudiantesDTO con la información actualizada del estudiante.
     * @return int Indicador del resultado de la operación.
     */
  public int actualizar(EstudiantesDTO estudiante) {
    int r = 0;
    String sql = "UPDATE estudiantes SET matricula = ?, nombres = ?, apellidos = ?, correo_electronico = ?, numero_telefono = ? WHERE id = ?";
    try {
        con = conexion.conectarBaseDatos(); // Establecer la conexión
        ps = con.prepareStatement(sql); 

        // Establecer los nuevos valores para el estudiante
        ps.setInt(1, estudiante.getMatricula());
        ps.setString(2, estudiante.getNombres());
        ps.setString(3, estudiante.getApellidos());
        ps.setString(4, estudiante.getCorreo_electronico());
        ps.setString(5, estudiante.getNumero_telefono());
        ps.setInt(6, estudiante.getId()); 

        r = ps.executeUpdate(); 

        // Manejo adecuado de recursos
        ps.close();
        con.close();
    } catch (SQLException e) {
        System.out.println("Error al actualizar estudiante: " + e);
    } finally {
        try {
            if (ps != null) ps.close();
            if (con != null) con.close();
        } catch (SQLException e) {
            System.out.println("Error al cerrar los recursos: " + e);
        }
    }
    return r;
}//Fin de metodo actulizar
  /**
     * Elimina un estudiante de la base de datos según su identificador.
     * 
     * @param id Identificador (ID) del estudiante a eliminar.
     * @return int Indicador del resultado de la operación.
     */
  public int eliminar(int id) {
    int r = 0;
    String sql = "DELETE FROM estudiantes WHERE id = ?";

    try (Connection con = conexion.conectarBaseDatos();
         PreparedStatement ps = con.prepareStatement(sql)) {
        
        ps.setInt(1, id);
        r = ps.executeUpdate();

        return r;
    } catch (SQLException e) {
        System.out.println("Error al tratar de borrar el estudiante: " + e);
    }
    return r; 
}//Fin del metodo eliminar
   /**
     * Busca estudiantes en la base de datos que coincidan con el valor proporcionado.
     * La búsqueda se realiza en todas las columnas de la tabla de estudiantes.
     * 
     * @param valorBuscar Cadena de texto a buscar en los registros de estudiantes.
     * @return List<EstudiantesDTO> Lista de estudiantes que coinciden con el criterio de búsqueda.
     */
  public List<EstudiantesDTO> buscarEstudiante(String valorBuscar) {
    List<EstudiantesDTO> lista = new ArrayList<>();
    String sql = "SELECT * FROM estudiantes WHERE CONCAT(id, matricula, nombres, apellidos, correo_electronico, numero_telefono) LIKE '%" + valorBuscar + "%'";

    try {
        con = conexion.conectarBaseDatos();
        ps = con.prepareStatement(sql);
        rs = ps.executeQuery();

        while (rs.next()) {
            EstudiantesDTO estudiante = new EstudiantesDTO();
            estudiante.setId(rs.getInt("id"));
            estudiante.setMatricula(rs.getInt("matricula"));
            estudiante.setNombres(rs.getString("nombres"));
            estudiante.setApellidos(rs.getString("apellidos"));
            estudiante.setCorreo_electronico(rs.getString("correo_electronico"));
            estudiante.setNumero_telefono(rs.getString("numero_telefono"));
            lista.add(estudiante);
        }
    } catch (SQLException e) {
        System.out.println("Error al buscar estudiantes: " + e);
    } finally {
        // Cerrar recursos...
    }
    return lista;
}//Fin de buscar
  
}//Fin del metodo listar

// Ejemplo de uso:
// EstudiantesDAO estudiantesDao = new EstudiantesDAO();
// List<EstudiantesDTO> listaEstudiantes = estudiantesDao.Listar(); // Recuperar lista de estudiantes
// estudiantesDao.agregar(new EstudiantesDTO(...)); // Agregar un nuevo estudiante

