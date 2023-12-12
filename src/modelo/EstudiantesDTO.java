package modelo;


/**
 * Clase Data Transfer Object (DTO) para estudiantes.
 * Esta clase representa la estructura de datos para un estudiante y se utiliza para transferir datos
 * entre distintas capas de la aplicación, especialmente entre la base de datos y la lógica de negocio.
 *
 * @author bourdier
 */
public class EstudiantesDTO {
  private int id;
  private int matricula;
  private String nombres;
  private String apellidos;
  private String correo_electronico;
  private String numero_telefono;
  
  

  /**
     * Constructor vacío para crear una instancia sin inicializar los campos.
     */
  public EstudiantesDTO() {
    
  }

 /**
     * Constructor para crear un estudiante con todos los campos excepto el ID.
     * Útil para agregar estudiantes a la base de datos, donde el ID se genera automáticamente.
     *
     * @param matricula Matrícula del estudiante.
     * @param nombres Nombres del estudiante.
     * @param apellidos Apellidos del estudiante.
     * @param correo_electronico Correo electrónico del estudiante.
     * @param numero_telefono Número de teléfono del estudiante.
     */
  
  public EstudiantesDTO(int matricula, String nombres, String apellidos, String correo_electronico, String numero_telefono) {
    this.matricula = matricula;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.correo_electronico = correo_electronico;
    this.numero_telefono = numero_telefono;
  }
  
  /**
     * Constructor para crear un estudiante con todos los campos, incluido el ID.
     * Útil para actualizar los datos de un estudiante en la base de datos.
     *
     * @param id ID del estudiante.
     * @param matricula Matrícula del estudiante.
     * @param nombres Nombres del estudiante.
     * @param apellidos Apellidos del estudiante.
     * @param correo_electronico Correo electrónico del estudiante.
     * @param numero_telefono Número de teléfono del estudiante.
     */
  public EstudiantesDTO(int id, int matricula, String nombres, String apellidos, String correo_electronico, String numero_telefono) {
    this.id = id;
    this.matricula = matricula;
    this.nombres = nombres;
    this.apellidos = apellidos;
    this.correo_electronico = correo_electronico;
    this.numero_telefono = numero_telefono;
  }
  
  // Gettert and Setters modificadores de acceso

  public int getId() {
    return id;
  }

  public void setId(int id) {
    this.id = id;
  }

  public int getMatricula() {
    return matricula;
  }

  public void setMatricula(int matricula) {
    this.matricula = matricula;
  }

  public String getNombres() {
    return nombres;
  }

  public void setNombres(String nombres) {
    this.nombres = nombres;
  }

  public String getApellidos() {
    return apellidos;
  }

  public void setApellidos(String apellidos) {
    this.apellidos = apellidos;
  }

  public String getCorreo_electronico() {
    return correo_electronico;
  }

  public void setCorreo_electronico(String correo_electronico) {
    this.correo_electronico = correo_electronico;
  }

  public String getNumero_telefono() {
    return numero_telefono;
  }

  public void setNumero_telefono(String numero_telefono) {
    this.numero_telefono = numero_telefono;
  }
 
} //Fin de clase EstudiantesDTO
// Ejemplo de uso:
// EstudiantesDTO estudiante = new EstudiantesDTO(123, "Juan", "Pérez", "juan.perez@example.com", "555-1234");
// estudiante.setId(1); // Establecer el ID para un estudiante existente

