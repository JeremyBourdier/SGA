
package controlador;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.regex.Pattern;
import javax.swing.JOptionPane;
import modelo.SignUpDAO;
import modelo.Usuarios;
import vista.SignUp;

/**
 * Controlador para la interfaz de registro de usuario (SignUp).
 * Esta clase maneja las interacciones entre la vista de registro de usuario y el modelo de datos de usuario,
 * incluyendo la validación de entrada y la inserción de nuevos usuarios en la base de datos.
 * 
 * @author bourdier
 */
public class ControladorSignUp implements ActionListener {
  SignUpDAO signdao = new SignUpDAO();
  Usuarios user = new Usuarios();
  SignUp signv = new SignUp();
  
  /**
     * Constructor que inicializa el controlador con una vista de SignUp y un modelo de usuario.
     * Registra los oyentes de eventos para los botones de la interfaz de usuario.
     * 
     * @param signv La vista de SignUp que este controlador gestionará.
     * @param user El modelo de usuario para el registro de datos.
     */
  
  public ControladorSignUp (SignUp signv, Usuarios user){

    this.signv=signv;
    this.user=user;
    
    //Registro de usuarios
    this.signv.btnSignUp.addActionListener(this);
   
  }
  
   /**
     * Valida los campos de entrada en la vista de registro.
     * Comprueba si los campos están completos y si el correo electrónico es válido.
     * 
     * @return true si los campos son válidos, false en caso contrario.
     */
  
   private boolean validarCampos() {
    if (signv.txtnombreregistro.getText().trim().isEmpty() ||
        signv.txtcorreoregistro.getText().trim().isEmpty() ||
        signv.txtpasswordregistro.getText().trim().isEmpty()) {
      JOptionPane.showMessageDialog(null, "Por favor, completa todos los campos.");
      return false;
    }
    if (!validarEmail(signv.txtcorreoregistro.getText().trim())) {
      JOptionPane.showMessageDialog(null, "Por favor, introduce un correo electrónico válido.");
      return false;
    }
    return true;
  }
   
    /**
     * Valida la estructura de una dirección de correo electrónico.
     * Utiliza una expresión regular para comprobar el formato del correo.
     * 
     * @param email La dirección de correo electrónico a validar.
     * @return true si el correo electrónico es válido, false en caso contrario.
     */
   private boolean validarEmail(String email) {
    String regex = "^[\\w-_.+]*[\\w-_.]@([\\w]+\\.)+[\\w]+[\\w]$";
    return Pattern.matches(regex, email);
  }
   /**
     * Registra un nuevo usuario en el sistema.
     * Si los campos son válidos, asigna los valores al modelo de usuario y llama al DAO para insertar en la base de datos.
     */
  public void SignUp(){
    if (!validarCampos()) {
      return;
    }
    user.setNombre_completo(signv.txtnombreregistro.getText());
    user.setCorreo_electronico(signv.txtcorreoregistro.getText());
    user.setContraseña(signv.txtpasswordregistro.getText());
    
    if(signdao.InsertarUsuario(user)){
      JOptionPane.showMessageDialog(null, "Usuario registrado");
      
    }else{
      JOptionPane.showMessageDialog(null, "Error al resgistrar usuario");
      
    }
    
  }
  

    /**
     * Maneja las acciones realizadas en los componentes de la interfaz de usuario.
     * Este método se activa cuando un usuario interactúa con los botones de la interfaz de registro.
     * 
     * @param ae Evento de acción generado por la interfaz de usuario.
     */
  @Override
  public void actionPerformed(ActionEvent ae) {
    
    if (ae.getSource() == signv.btnSignUp) {
      SignUp();
    }     
    
  }
  
}

// Ejemplo de uso:
// SignUp signUpView = new SignUp();
// Usuarios userModel = new Usuarios();
// ControladorSignUp controlador = new ControladorSignUp(signUpView, userModel);
// controlador.actionPerformed(new ActionEvent(...)); // Ejemplo de cómo se podría disparar un evento de registro.
