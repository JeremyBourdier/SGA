package controlador;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.table.DefaultTableModel;
import modelo.EstudiantesDAO;
import modelo.EstudiantesDTO;
import vista.Principal;
import java.util.List;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;

/**
 * Controlador para gestionar las interacciones entre la vista Principal y el modelo de datos de Estudiantes.
 * Esta clase maneja eventos de la interfaz de usuario y actualiza la vista y el modelo de datos correspondientemente.
 *
 * @author bourdier
 */
public class ControladorEstudiante implements ActionListener {

  EstudiantesDAO estudiantedao = new EstudiantesDAO();
  Principal vistaPrincipal = new Principal();
  DefaultTableModel modeloTabla = new DefaultTableModel();
  
  /**
     * Constructor para inicializar el controlador con una vista principal.
     * Registra los oyentes de eventos y carga los datos iniciales en la tabla.
     *
     * @param vistaPrincipal La vista principal que este controlador gestionará.
     */

  public ControladorEstudiante(Principal vistaPrincipal) {
    this.vistaPrincipal = vistaPrincipal;
    vistaPrincipal.setVisible(true);
    agregarEventos();
    listarTabla();
    
    vistaPrincipal.getTxtBuscar().getDocument().addDocumentListener(new DocumentListener() {
        @Override
        public void insertUpdate(DocumentEvent e) {
            buscarEstudiante();
        }

        @Override
        public void removeUpdate(DocumentEvent e) {
            buscarEstudiante();
        }

        @Override
        public void changedUpdate(DocumentEvent e) {
            buscarEstudiante();
        }
    });
  }
  

  private void agregarEventos() {
    vistaPrincipal.getBtnAgregar().addActionListener(this);
    vistaPrincipal.getBtnActualizar().addActionListener(this);
    vistaPrincipal.getBtnBorrar().addActionListener(this);
    vistaPrincipal.getBtnBuscar().addActionListener(this);
    vistaPrincipal.getTblEstudiantes().addMouseListener(new MouseAdapter() {
      public void mouseClicked(MouseEvent e){
        llenarCampos(e);
      }

    });
  }
  
  private void listarTabla() {
    String[] titulos = new String[]{"Id", "Matricula", "Nombres", "Apellidos", "Correo", "Numero de telefono"};
    modeloTabla = new DefaultTableModel(titulos, 0);
    List<EstudiantesDTO> listaEstudiantes = estudiantedao.Listar();
    for (EstudiantesDTO estudiante : listaEstudiantes) {
      modeloTabla.addRow(new Object[]{estudiante.getId(), estudiante.getMatricula(), estudiante.getNombres(), estudiante.getApellidos(), estudiante.getCorreo_electronico(), estudiante.getNumero_telefono()});
      
    }
    vistaPrincipal.getTblEstudiantes().setModel(modeloTabla);
    vistaPrincipal.getTblEstudiantes().setPreferredSize(new Dimension(350, modeloTabla.getRowCount() * 16));
  }
  
  private void llenarCampos(MouseEvent e){
    JTable target = (JTable) e.getSource();
    vistaPrincipal.getTxtId().setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 0) .toString());
    vistaPrincipal.getTxtMatricula().setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 1) .toString());
     vistaPrincipal.getTxtNombres () .setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 2) .toString());
      vistaPrincipal.getTxtApellidos().setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 3) .toString());
       vistaPrincipal.getTxtCorreo().setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 4) .toString());
        vistaPrincipal.getTxtTelefono().setText (vistaPrincipal.getTblEstudiantes().getModel () .getValueAt (target .getSelectedRow(), 5) .toString());
  }
  
  public void limpiarCampos() {
        vistaPrincipal.getTxtId().setText("");
        vistaPrincipal.getTxtMatricula().setText("");
        vistaPrincipal.getTxtNombres().setText("");
        vistaPrincipal.getTxtApellidos().setText("");
        vistaPrincipal.getTxtCorreo().setText("");
        vistaPrincipal.getTxtTelefono().setText("");
        vistaPrincipal.getTxtBuscar().setText("");
        vistaPrincipal.getTxtNombres().requestFocus();
    }

  

    /**
     * Maneja las acciones realizadas en los componentes de la interfaz de usuario.
     * Este método se activa cuando un usuario interactúa con elementos de la interfaz
     * que tienen un oyente de acción asociado.
     *
     * @param ae Evento de acción generado por la interfaz de usuario.
     */
  @Override
  public void actionPerformed(ActionEvent ae) {
    if (ae.getSource() == vistaPrincipal.getBtnAgregar()) {
      if (validarCampos() > 0){}
        EstudiantesDTO estudiante = new EstudiantesDTO(
            Integer.parseInt(vistaPrincipal.getTxtMatricula().getText()),
            vistaPrincipal.getTxtNombres().getText(),
            vistaPrincipal.getTxtApellidos().getText(),
            vistaPrincipal.getTxtCorreo().getText(),
            vistaPrincipal.getTxtTelefono().getText()
        );
        
        int resultado = estudiantedao.agregar(estudiante);
        if (resultado > 0) {
            JOptionPane.showMessageDialog(vistaPrincipal, "Estudiante agregado con éxito.");
            listarTabla();
            limpiarCampos();
        } else {
            JOptionPane.showMessageDialog(vistaPrincipal, "Error al agregar estudiante.");
        }
    }else if (ae.getSource() == vistaPrincipal.getBtnActualizar()) {
        actualizarEstudiante();
    }else if (ae.getSource() == vistaPrincipal.getBtnBorrar()) {
        eliminarEstudiante();
    }else if (ae.getSource() == vistaPrincipal.getBtnBuscar()) {
        buscarEstudiante();
        limpiarCampos();
    }
  }
  
  public void actualizarEstudiante() {
    int filaSeleccionada = vistaPrincipal.getTblEstudiantes().getSelectedRow();
    if (filaSeleccionada == -1) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Debe seleccionar un estudiante para actualizar.");
        return;
    }
    try {
        int id = Integer.parseInt(vistaPrincipal.getTblEstudiantes().getValueAt(filaSeleccionada, 0).toString());
        int matricula = Integer.parseInt(vistaPrincipal.getTxtMatricula().getText());
        String nombres = vistaPrincipal.getTxtNombres().getText();
        String apellidos = vistaPrincipal.getTxtApellidos().getText();
        String correo = vistaPrincipal.getTxtCorreo().getText();
        String telefono = vistaPrincipal.getTxtTelefono().getText();

        // Crear el objeto DTO con los datos actualizados
        EstudiantesDTO estudianteActualizado = new EstudiantesDTO(id, matricula, nombres, apellidos, correo, telefono);

        // Llamar al método actualizar del DAO
        int resultado = estudiantedao.actualizar(estudianteActualizado);
        if (resultado > 0) {
            JOptionPane.showMessageDialog(vistaPrincipal, "Estudiante actualizado con éxito.");
            listarTabla();
            limpiarCampos();
        } else {
            JOptionPane.showMessageDialog(vistaPrincipal, "Error al actualizar estudiante.");
        }
    } catch (NumberFormatException e) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Error en el formato de los datos: " + e.getMessage());
    }
}//Fin de actulizar

  private void eliminarEstudiante() {
    int filaSeleccionada = vistaPrincipal.getTblEstudiantes().getSelectedRow();
    if (filaSeleccionada == -1) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Debe seleccionar un estudiante para eliminar.");
        return;
    }

    int confirmacion = JOptionPane.showConfirmDialog(vistaPrincipal, "¿Está seguro de que desea eliminar este estudiante?");
    if (confirmacion == JOptionPane.YES_OPTION) {
        try {
            int id = Integer.parseInt(vistaPrincipal.getTblEstudiantes().getValueAt(filaSeleccionada, 0).toString());
            int resultado = estudiantedao.eliminar(id);
            if (resultado > 0) {
                JOptionPane.showMessageDialog(vistaPrincipal, "Estudiante eliminado con éxito.");
                listarTabla();
                limpiarCampos();
            } else {
                JOptionPane.showMessageDialog(vistaPrincipal, "Error al eliminar estudiante.");
            }
        } catch (NumberFormatException e) {
            JOptionPane.showMessageDialog(vistaPrincipal, "Error al intentar obtener el ID del estudiante.");
        }
    }else {
        limpiarCampos(); // Limpia los campos si el usuario selecciona "No" o "Cancelar".
    }
  }//Fin de eliminar

  private void buscarEstudiante() {
    String texto = vistaPrincipal.getTxtBuscar().getText();
    List<EstudiantesDTO> lista = estudiantedao.buscarEstudiante(texto);
    actualizarTablaConLista(lista);
}//Fin de buscar estudiante

private void actualizarTablaConLista(List<EstudiantesDTO> lista) {
    DefaultTableModel modelo = (DefaultTableModel) vistaPrincipal.getTblEstudiantes().getModel();
    modelo.setRowCount(0); // Limpiar la tabla
    for (EstudiantesDTO estudiante : lista) {
        Object[] fila = new Object[6];
        fila[0] = estudiante.getId();
        fila[1] = estudiante.getMatricula();
        fila[2] = estudiante.getNombres();
        fila[3] = estudiante.getApellidos();
        fila[4] = estudiante.getCorreo_electronico();
        fila[5] = estudiante.getNumero_telefono();
        modelo.addRow(fila);
    }
  }//fin de actulizar la tabla con las coincidencias

public int validarCampos() {
    int validacion = 1;

    if (vistaPrincipal.getTxtNombres().getText().trim().isEmpty()) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Favor verificar campo nombres, no puede estar vacio.", "Error!", JOptionPane.ERROR_MESSAGE);
        vistaPrincipal.getTxtNombres().requestFocus();
        validacion = 0;
    } else if (vistaPrincipal.getTxtApellidos().getText().trim().isEmpty()) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Favor verificar campo apellidos, no puede estar vacio.", "Error!", JOptionPane.ERROR_MESSAGE);
        vistaPrincipal.getTxtApellidos().requestFocus();
        validacion = 0;
    } else if (vistaPrincipal.getTxtCorreo().getText().trim().isEmpty()) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Favor verificar campo correo, no puede estar vacio.", "Error!", JOptionPane.ERROR_MESSAGE);
        vistaPrincipal.getTxtCorreo().requestFocus();
        validacion = 0;
    } else if (vistaPrincipal.getTxtTelefono().getText().trim().isEmpty()) {
        JOptionPane.showMessageDialog(vistaPrincipal, "Favor verificar campo telefono, no puede estar vacio.", "Error!", JOptionPane.ERROR_MESSAGE);
        vistaPrincipal.getTxtTelefono().requestFocus();
        validacion = 0;
    } 


    return validacion;
}//Fin de validar

}//Fin de clase ControladorEstudiante
