package modelo;

import java.sql.SQLException;

/**
 * Clase que representa la entidad de Usuario en el modelo de datos.
 * Contiene propiedades para el nombre completo, correo electrónico y contraseña del usuario,
 * junto con métodos para obtener y establecer estos valores.
 *
 * @author bourdier
 */

public class Usuarios {
  private String nombre_completo;
  private String correo_electronico;
  private String contraseña;

  /**
     * Establece el nombre completo del usuario.
     * 
     * @param nombre_completo El nombre completo a establecer para el usuario.
     */
  public String getNombre_completo() {
    return nombre_completo;
  }

  /**
     * Obtiene el correo electrónico del usuario.
     * 
     * @return El correo electrónico del usuario.
     */
  public void setNombre_completo(String nombre_completo) {
    this.nombre_completo = nombre_completo;
  }

   /**
     * Establece el correo electrónico del usuario.
     * 
     * @param correo_electronico El correo electrónico a establecer para el usuario.
     */
  public String getCorreo_electronico() {
    return correo_electronico;
  }

  /**
   * @param correo_electronico the correo_electronico to set
   */
  public void setCorreo_electronico(String correo_electronico) {
    this.correo_electronico = correo_electronico;
  }

  /**
     * Obtiene la contraseña del usuario.
     * 
     * @return La contraseña del usuario.
     */
  public String getContraseña() {
    return contraseña;
  }

  /**
     * Establece la contraseña del usuario.
     * 
     * @param contraseña La contraseña a establecer para el usuario.
     */
  public void setContraseña(String contraseña) {
    this.contraseña = contraseña;
  } 
}
// Ejemplo de uso:
// Usuarios usuario = new Usuarios();
// usuario.setNombre_completo("Juan Pérez");
// usuario.setCorreo_electronico("juan.perez@example.com");
// usuario.setContraseña("contraseña123");
// String nombre = usuario.getNombre_completo();
// String correo = usuario.getCorreo_electronico();
// String contraseña = usuario.getContraseña();
