package controlador;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JOptionPane;
import modelo.LoginDAO;
import modelo.Usuarios;
import vista.Login;
import vista.Principal;
import vista.SignUp;

/**
 * Controlador para la interfaz de login de usuario.
 * Esta clase maneja las interacciones entre la vista de login y el modelo de datos de usuario,
 * incluyendo la autenticación y la navegación hacia otras vistas como el registro de usuario.
 * 
 * @author bourdier
 */
public class ControladorLogin implements ActionListener {
    private Login loginv;
    private LoginDAO logindao;
    
    /**
     * Constructor que inicializa el controlador con una vista de login.
     * Registra los oyentes de eventos para los botones de la interfaz de usuario.
     * 
     * @param loginv La vista de login que este controlador gestionará.
     */

    public ControladorLogin(Login loginv) {
        this.logindao = new LoginDAO();
        this.loginv = loginv;
        this.loginv.setVisible(true);
        this.loginv.pack();
        this.loginv.setLocationRelativeTo(null);
        

        this.loginv.btnLogin.addActionListener(this);
        this.loginv.btnSignUp.addActionListener(this);
        this.loginv.BtnCancelar.addActionListener(this);
    }
    
    /**
     * Maneja las acciones realizadas en los componentes de la interfaz de usuario.
     * Este método se activa cuando un usuario interactúa con los botones de la interfaz de login.
     * 
     * @param e Evento de acción generado por la interfaz de usuario.
     */

    @Override
public void actionPerformed(ActionEvent e) {
    if (e.getSource() == loginv.btnLogin) {
        String usuario = loginv.txtcorreologin.getText();
        String contraseña = String.valueOf(loginv.txtpasswordlogin.getPassword());
        
        if (logindao.Autenticacion(usuario, contraseña)) {
            loginv.setVisible(false); // Oculta la ventana de login
            Principal vistaPrincipal = new Principal(); // Crea una instancia de tu ventana principal
            ControladorEstudiante controladorEstudiante = new ControladorEstudiante(vistaPrincipal);
        } else {
            JOptionPane.showMessageDialog(loginv, "Usuario o contraseña incorrectos", "Error", JOptionPane.ERROR_MESSAGE);
        }
    } else if (e.getSource() == loginv.BtnCancelar) {
        System.exit(0); // Cierra la aplicación
    } else if (e.getSource() == loginv.btnSignUp) {
        abrirSignUp();
    }
}
    /**
     * Abre la ventana de registro de usuario (SignUp).
     * Crea y muestra la interfaz de usuario para el registro de nuevos usuarios.
     */
     private void abrirSignUp() {
        // Crear una instancia de la vista y el modelo para SignUp
        SignUp signUpView = new SignUp();
        Usuarios userModel = new Usuarios();

        // Crear una instancia del controlador SignUp y mostrar la vista
        ControladorSignUp controladorSignUp = new ControladorSignUp(signUpView, userModel);
        signUpView.setVisible(true);
    }

     /**
     * Método principal para iniciar la aplicación.
     * Crea y muestra la ventana de login.
     * 
     * @param args Argumentos de la línea de comandos (no utilizados en este caso).
     */
    public static void main(String args[]) {
        Login loginFrame = new Login();
        new ControladorLogin(loginFrame);
    }
}

// Ejemplo de uso:
// Login loginFrame = new Login();
// ControladorLogin controlador = new ControladorLogin(loginFrame);
// controlador.actionPerformed(new ActionEvent(...)); // Ejemplo de cómo se podría disparar un evento.
