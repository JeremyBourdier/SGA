package controlador;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import javax.swing.JOptionPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import modelo.PersonalesDAO;
import modelo.PersonalesDTO;
import vista.DatosPersonales;
import java.util.List;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author bourdier
 */
/**
 * Controlador para manejar operaciones CRUD en registros de datos personales.
 * Interactúa con PersonalesDAO para operaciones de base de datos y actualiza
 * la interfaz de usuario DatosPersonales.
 */

public class ControladorPersonales implements ActionListener {

    PersonalesDAO personalesDAO = new PersonalesDAO();
    DatosPersonales vistaDatosPersonales = new DatosPersonales();
    DefaultTableModel modeloTabla = new DefaultTableModel();
    

 /**
     * Constructor que inicializa la vista DatosPersonales, configura los modelos
     * de tabla, agrega listeners y carga datos iniciales.
     * 
     * @param vistaDatosPersonales Vista asociada a este controlador.
     */
    public ControladorPersonales(DatosPersonales vistaDatosPersonales) {
        this.vistaDatosPersonales = vistaDatosPersonales;
        modeloTabla = new DefaultTableModel();
        vistaDatosPersonales.setVisible(true);
        vistaDatosPersonales.getBtnAgregar().addActionListener(e -> agregarPersonal());
        vistaDatosPersonales.getBtnActualizar().addActionListener(e -> actualizarPersonal());
        vistaDatosPersonales.getBtnBorrar().addActionListener(e -> eliminarPersonal());
        vistaDatosPersonales.getBtnRefrescar().addActionListener(e -> buscarPersonal());
        agregarEventos();
        listarTabla();

        vistaDatosPersonales.getTxtBuscar().getDocument().addDocumentListener(new DocumentListener() {
            public void insertUpdate(DocumentEvent e) {
                buscarPersonal();
            }

            public void removeUpdate(DocumentEvent e) {
                buscarPersonal();
            }

            public void changedUpdate(DocumentEvent e) {
                buscarPersonal();
            }
        });
    }

    private void agregarEventos() {
        vistaDatosPersonales.getBtnAgregar().addActionListener(this);
        vistaDatosPersonales.getBtnActualizar().addActionListener(this);
        vistaDatosPersonales.getBtnBorrar().addActionListener(this);
        vistaDatosPersonales.getBtnRefrescar().addActionListener(this);
        vistaDatosPersonales.getTblPersonales().addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent e) {
                llenarCampos(e);
            }
        });
    }

    private void listarTabla() {
        String[] titulos = {"Id", "Fecha Nacimiento", "Sexo", "Contacto Emergencia", "Carrera Actual"};
        modeloTabla = new DefaultTableModel(null, titulos);
        List<PersonalesDTO> listaPersonales = personalesDAO.listar();

        for (PersonalesDTO personal : listaPersonales) {
            Object[] rowData = {
                personal.getId(),
                personal.getFechaNacimiento(),
                personal.getSexo(),
                personal.getContactoEmergencia(),
                personal.getCarreraActual()
            };
            modeloTabla.addRow(rowData);
        }
        vistaDatosPersonales.getTblPersonales().setModel(modeloTabla);
    }

    private void llenarCampos(MouseEvent e) {
        JTable target = (JTable) e.getSource();
        int fila = target.getSelectedRow();
        vistaDatosPersonales.getTxtId().setText(target.getModel().getValueAt(fila, 0).toString());
        vistaDatosPersonales.getTxtFechaNacimiento().setText(target.getModel().getValueAt(fila, 1).toString());
        vistaDatosPersonales.getTxtSexo().setText(target.getModel().getValueAt(fila, 2).toString());
        vistaDatosPersonales.getTxtContactoEmergencia().setText(target.getModel().getValueAt(fila, 3).toString());
        vistaDatosPersonales.getTxtCarreraActual().setText(target.getModel().getValueAt(fila, 4).toString());
    }

    private void limpiarCampos() {
        vistaDatosPersonales.getTxtId().setText("");
        vistaDatosPersonales.getTxtFechaNacimiento().setText("");
        vistaDatosPersonales.getTxtSexo().setText("");
        vistaDatosPersonales.getTxtContactoEmergencia().setText("");
        vistaDatosPersonales.getTxtCarreraActual().setText("");
        vistaDatosPersonales.getTxtBuscar().setText("");
    }

    @Override
    public void actionPerformed(ActionEvent ae) {
        if (ae.getSource() == vistaDatosPersonales.getBtnAgregar()) {
            agregarPersonal();
        } else if (ae.getSource() == vistaDatosPersonales.getBtnActualizar()) {
            actualizarPersonal();
        } else if (ae.getSource() == vistaDatosPersonales.getBtnBorrar()) {
            eliminarPersonal();
        } else if (ae.getSource() == vistaDatosPersonales.getBtnRefrescar()) {
            buscarPersonal();
        }
    }

    private void agregarPersonal() {
        try {
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            Date fechaNacimiento = format.parse(vistaDatosPersonales.getTxtFechaNacimiento().getText());
            String sexo = vistaDatosPersonales.getTxtSexo().getText();
            String contactoEmergencia = vistaDatosPersonales.getTxtContactoEmergencia().getText();
            String carreraActual = vistaDatosPersonales.getTxtCarreraActual().getText();

            PersonalesDTO personal = new PersonalesDTO(fechaNacimiento, sexo, contactoEmergencia, carreraActual);
            if (personalesDAO.agregar(personal) > 0) {
                JOptionPane.showMessageDialog(vistaDatosPersonales, "Personal agregado con éxito.");
                listarTabla();
                limpiarCampos();
            } else {
                JOptionPane.showMessageDialog(vistaDatosPersonales, "Error al agregar personal.");
            }
        } catch (Exception e) {
            JOptionPane.showMessageDialog(vistaDatosPersonales, "Error en el formato de fecha: " + e.getMessage());
        }
    }

    private void actualizarPersonal() {
        int filaSeleccionada = vistaDatosPersonales.getTblPersonales().getSelectedRow();
    if (filaSeleccionada == -1) {
        JOptionPane.showMessageDialog(vistaDatosPersonales, "Debe seleccionar un registro para actualizar.");
        return;
    }

    try {
        int id = Integer.parseInt(vistaDatosPersonales.getTblPersonales().getValueAt(filaSeleccionada, 0).toString());
        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
        Date fechaNacimiento = format.parse(vistaDatosPersonales.getTxtFechaNacimiento().getText());
        String sexo = vistaDatosPersonales.getTxtSexo().getText();
        String contactoEmergencia = vistaDatosPersonales.getTxtContactoEmergencia().getText();
        String carreraActual = vistaDatosPersonales.getTxtCarreraActual().getText();

        PersonalesDTO personalActualizado = new PersonalesDTO(id, fechaNacimiento, sexo, contactoEmergencia, carreraActual);
        int resultado = personalesDAO.actualizar(personalActualizado);

        if (resultado > 0) {
            JOptionPane.showMessageDialog(vistaDatosPersonales, "Registro actualizado con éxito.");
            listarTabla();
            limpiarCampos();
        } else {
            JOptionPane.showMessageDialog(vistaDatosPersonales, "Error al actualizar el registro.");
        }
    } catch (Exception e) {
        JOptionPane.showMessageDialog(vistaDatosPersonales, "Error al actualizar: " + e.getMessage());
    }
    }

    private void eliminarPersonal() {
      int filaSeleccionada = vistaDatosPersonales.getTblPersonales().getSelectedRow();
    if (filaSeleccionada == -1) {
        JOptionPane.showMessageDialog(vistaDatosPersonales, "Debe seleccionar un registro para eliminar.");
        return;
    }

    int confirmacion = JOptionPane.showConfirmDialog(vistaDatosPersonales, "¿Está seguro de que desea eliminar este registro?");
    if (confirmacion == JOptionPane.YES_OPTION) {
        int id = Integer.parseInt(vistaDatosPersonales.getTblPersonales().getValueAt(filaSeleccionada, 0).toString());
        int resultado = personalesDAO.eliminar(id);

        if (resultado > 0) {
            JOptionPane.showMessageDialog(vistaDatosPersonales, "Registro eliminado con éxito.");
            listarTabla();
            limpiarCampos();
        } else {
            JOptionPane.showMessageDialog(vistaDatosPersonales, "Error al eliminar el registro.");
        }
    }
        
    }

    private void buscarPersonal() {
        String texto = vistaDatosPersonales.getTxtBuscar().getText();
    List<PersonalesDTO> lista = personalesDAO.buscarPersonal(texto);
    actualizarTablaConLista(lista);
}

private void actualizarTablaConLista(List<PersonalesDTO> lista) {
    modeloTabla.setRowCount(0); // Limpiar la tabla
    for (PersonalesDTO personal : lista) {
        modeloTabla.addRow(new Object[]{
            personal.getId(),
            personal.getFechaNacimiento(),
            personal.getSexo(),
            personal.getContactoEmergencia(),
            personal.getCarreraActual()
        });
    }
    }

private boolean validarCampos() {
    if (vistaDatosPersonales.getTxtFechaNacimiento().getText().trim().isEmpty() ||
        vistaDatosPersonales.getTxtSexo().getText().trim().isEmpty() ||
        vistaDatosPersonales.getTxtContactoEmergencia().getText().trim().isEmpty() ||
        vistaDatosPersonales.getTxtCarreraActual().getText().trim().isEmpty()) {
        
        JOptionPane.showMessageDialog(vistaDatosPersonales, "Todos los campos son obligatorios.");
        return false;
    }
    // Aquí se pueden agregar más validaciones si es necesario
    return true;
}

  public DatosPersonales getVistaDatosPersonales() {
    return vistaDatosPersonales;
  }

  public void setVistaDatosPersonales(DatosPersonales vistaDatosPersonales) {
    this.vistaDatosPersonales = vistaDatosPersonales;
  }
    
    
  
}
    

