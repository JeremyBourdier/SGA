
package modelo;

import java.sql.Connection;
import controlador.ConexionBD;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;
import java.sql.SQLException;
import java.sql.PreparedStatement;
import java.util.Date;

/**
 *
 * @author bourdier
 */
public class PersonalesDAO {
  ConexionBD conexion = new ConexionBD();
    Connection con;
    PreparedStatement ps;
    ResultSet rs;

    /**
     * Recupera una lista de todos los registros personales en la base de datos.
     * 
     * @return Lista de objetos PersonalesDTO con los datos.
     */
    public List<PersonalesDTO> listar() {
        String sql = "SELECT * FROM datos_personales";
        List<PersonalesDTO> lista = new ArrayList<>();
        try {
            con = conexion.conectarBaseDatos();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while (rs.next()) {
                PersonalesDTO personal = new PersonalesDTO();
                personal.setId(rs.getInt("id"));
                personal.setFechaNacimiento(rs.getDate("fecha_nacimiento"));
                personal.setSexo(rs.getString("sexo"));
                personal.setContactoEmergencia(rs.getString("contacto_emergencia"));
                personal.setCarreraActual(rs.getString("carrera_actual"));
                lista.add(personal);
            }
        } catch (SQLException e) {
            System.out.println("Error al listar personales: " + e);
        } finally {
            cerrarRecursos();
        }
        return lista;
    }

    /**
     * Agrega un nuevo registro personal a la base de datos.
     * 
     * @param personal Objeto PersonalesDTO con la información a agregar.
     * @return int Indicador del resultado de la operación.
     */
    public int agregar(PersonalesDTO personal) {
        int r = 0;
        String sql = "INSERT INTO datos_personales (fecha_nacimiento, sexo, contacto_emergencia, carrera_actual) VALUES (?, ?, ?, ?)";
        try {
            con = conexion.conectarBaseDatos();
            ps = con.prepareStatement(sql);

            ps.setDate(1, new java.sql.Date(personal.getFechaNacimiento().getTime()));
            ps.setString(2, personal.getSexo());
            ps.setString(3, personal.getContactoEmergencia());
            ps.setString(4, personal.getCarreraActual());

            r = ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error al agregar personal: " + e);
        } finally {
            cerrarRecursos();
        }
        return r;
    }

    /**
     * Actualiza la información de un registro personal existente en la base de datos.
     * 
     * @param personal Objeto PersonalesDTO con la información actualizada.
     * @return int Indicador del resultado de la operación.
     */
    public int actualizar(PersonalesDTO personal) {
        int r = 0;
        String sql = "UPDATE datos_personales SET fecha_nacimiento = ?, sexo = ?, contacto_emergencia = ?, carrera_actual = ? WHERE id = ?";
        try {
            con = conexion.conectarBaseDatos();
            ps = con.prepareStatement(sql);

            ps.setDate(1, new java.sql.Date(personal.getFechaNacimiento().getTime()));
            ps.setString(2, personal.getSexo());
            ps.setString(3, personal.getContactoEmergencia());
            ps.setString(4, personal.getCarreraActual());
            ps.setInt(5, personal.getId());

            r = ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error al actualizar personal: " + e);
        } finally {
            cerrarRecursos();
        }
        return r;
    }

    /**
     * Elimina un registro personal de la base de datos según su identificador.
     * 
     * @param id Identificador (ID) del personal a eliminar.
     * @return int Indicador del resultado de la operación.
     */
    public int eliminar(int id) {
        int r = 0;
        String sql = "DELETE FROM datos_personales WHERE id = ?";
        try {
            con = conexion.conectarBaseDatos();
            ps = con.prepareStatement(sql);

            ps.setInt(1, id);

            r = ps.executeUpdate();
        } catch (SQLException e) {
            System.out.println("Error al eliminar personal: " + e);
        } finally {
            cerrarRecursos();
        }
        return r;
    }

    /**
     * Busca registros personales en la base de datos que coincidan con el valor proporcionado.
     * 
     * @param valorBuscar Cadena de texto a buscar en los registros.
     * @return List<PersonalesDTO> Lista de personales que coinciden con el criterio de búsqueda.
     */
    public List<PersonalesDTO> buscarPersonal(String valorBuscar) {
        List<PersonalesDTO> lista = new ArrayList<>();
        String sql = "SELECT * FROM datos_personales WHERE CONCAT(id, fecha_nacimiento, sexo, contacto_emergencia, carrera_actual) LIKE '%" + valorBuscar + "%'";
        try {
            con = conexion.conectarBaseDatos();
            ps = con.prepareStatement(sql);
            rs = ps.executeQuery();
            while (rs.next()) {
                PersonalesDTO personal = new PersonalesDTO();
                personal.setId(rs.getInt("id"));
                personal.setFechaNacimiento(rs.getDate("fecha_nacimiento"));
                personal.setSexo(rs.getString("sexo"));
                personal.setContactoEmergencia(rs.getString("contacto_emergencia"));
                personal.setCarreraActual(rs.getString("carrera_actual"));
                lista.add(personal);
            }
        } catch (SQLException e) {
            System.out.println("Error al buscar personales: " + e);
        } finally {
            cerrarRecursos();
        }
        return lista;
    }

    /**
     * Cierra los recursos de la base de datos.
     */
    private void cerrarRecursos() {
        try {
            if (rs != null) rs.close();
            if (ps != null) ps.close();
            if (con != null) con.close();
        } catch (SQLException e) {
            System.out.println("Error al cerrar los recursos: " + e);
        }
    }
  
}//fin de perosonalesDAO
