
package modelo;

import java.util.Date;

/**
 *
 * @author bourdier
 */
public class PersonalesDTO {
    private int id;
    private Date fechaNacimiento;
    private String sexo;
    private String contactoEmergencia;
    private String carreraActual;

    /**
     * Constructor vacío para crear una instancia sin inicializar los campos.
     */
    public PersonalesDTO() {
        
    }

    /**
     * Constructor para crear un estudiante con todos los campos excepto el ID.
     */
    public PersonalesDTO(Date fechaNacimiento, String sexo, String contactoEmergencia, String carreraActual) {
        this.fechaNacimiento = fechaNacimiento;
        this.sexo = sexo;
        this.contactoEmergencia = contactoEmergencia;
        this.carreraActual = carreraActual;
    }

    /**
     * Constructor para crear un estudiante con todos los campos, incluido el ID.
     */
    public PersonalesDTO(int id, Date fechaNacimiento, String sexo, String contactoEmergencia, String carreraActual) {
        this.id = id;
        this.fechaNacimiento = fechaNacimiento;
        this.sexo = sexo;
        this.contactoEmergencia = contactoEmergencia;
        this.carreraActual = carreraActual;
    }

    // Getters and Setters

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public Date getFechaNacimiento() {
        return fechaNacimiento;
    }

    public void setFechaNacimiento(Date fechaNacimiento) {
        this.fechaNacimiento = fechaNacimiento;
    }

    public String getSexo() {
        return sexo;
    }

    public void setSexo(String sexo) {
        this.sexo = sexo;
    }

    public String getContactoEmergencia() {
        return contactoEmergencia;
    }

    public void setContactoEmergencia(String contactoEmergencia) {
        this.contactoEmergencia = contactoEmergencia;
    }

    public String getCarreraActual() {
        return carreraActual;
    }

    public void setCarreraActual(String carreraActual) {
        this.carreraActual = carreraActual;
    }

  
}//Fin de personalesDTO
