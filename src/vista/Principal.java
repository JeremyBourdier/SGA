package vista;

import controlador.ControladorEstudiante;
import controlador.ControladorPersonales;
import java.awt.BorderLayout;
import javax.swing.JPanel;
import modelo.PersonalesDAO;

/**
 * Vista del formulario del estudiante
 * @author bourdier
 */

public class Principal extends javax.swing.JFrame {

  
  /**
   * @return the btnActualizar
   */
  
  public javax.swing.JButton getBtnActualizar() {
    return btnActualizar;
  }

  /**
   * @param btnActualizar the btnActualizar to set
   */
  public void setBtnActualizar(javax.swing.JButton btnActualizar) {
    this.btnActualizar = btnActualizar;
  }

  /**
   * @return the btnAgregar
   */
  public javax.swing.JButton getBtnAgregar() {
    return btnAgregar;
  }

  /**
   * @param btnAgregar the btnAgregar to set
   */
  public void setBtnAgregar(javax.swing.JButton btnAgregar) {
    this.btnAgregar = btnAgregar;
  }



  /**
   * @return the btnBorrar
   */
  public javax.swing.JButton getBtnBorrar() {
    return btnBorrar;
  }

  /**
   * @param btnBorrar the btnBorrar to set
   */
  public void setBtnBorrar(javax.swing.JButton btnBorrar) {
    this.btnBorrar = btnBorrar;
  }

  /**
   * @return the btnBuscar
   */
  public javax.swing.JButton getBtnBuscar() {
    return btnBuscar;
  }

  /**
   * @param btnBuscar the btnBuscar to set
   */
  public void setBtnBuscar(javax.swing.JButton btnBuscar) {
    this.btnBuscar = btnBuscar;
  }

  /**
   * @return the jApellidos
   */
  public javax.swing.JLabel getjApellidos() {
    return jApellidos;
  }

  /**
   * @param jApellidos the jApellidos to set
   */
  public void setjApellidos(javax.swing.JLabel jApellidos) {
    this.jApellidos = jApellidos;
  }

  /**
   * @return the jCorreo
   */
  public javax.swing.JLabel getjCorreo() {
    return jCorreo;
  }

  /**
   * @param jCorreo the jCorreo to set
   */
  public void setjCorreo(javax.swing.JLabel jCorreo) {
    this.jCorreo = jCorreo;
  }

  /**
   * @return the jId
   */
  public javax.swing.JLabel getjId() {
    return jId;
  }

  /**
   * @param jId the jId to set
   */
  public void setjId(javax.swing.JLabel jId) {
    this.jId = jId;
  }

  /**
   * @return the jLabel1
   */
  public javax.swing.JLabel getjLabel1() {
    return jLabel1;
  }

  /**
   * @param jLabel1 the jLabel1 to set
   */
  public void setjLabel1(javax.swing.JLabel jLabel1) {
    this.jLabel1 = jLabel1;
  }

  /**
   * @return the jLabel2
   */
  public javax.swing.JLabel getjLabel2() {
    return jLabel2;
  }

  /**
   * @param jLabel2 the jLabel2 to set
   */
  public void setjLabel2(javax.swing.JLabel jLabel2) {
    this.jLabel2 = jLabel2;
  }

  /**
   * @return the jLabel3
   */
  public javax.swing.JLabel getjLabel3() {
    return jLabel3;
  }

  /**
   * @param jLabel3 the jLabel3 to set
   */
  public void setjLabel3(javax.swing.JLabel jLabel3) {
    this.jLabel3 = jLabel3;
  }

  /**
   * @return the jMatricula
   */
  public javax.swing.JLabel getjMatricula() {
    return jMatricula;
  }

  /**
   * @param jMatricula the jMatricula to set
   */
  public void setjMatricula(javax.swing.JLabel jMatricula) {
    this.jMatricula = jMatricula;
  }

 
  /**
   * @return the jNombres
   */
  public javax.swing.JLabel getjNombres() {
    return jNombres;
  }

  /**
   * @param jNombres the jNombres to set
   */
  public void setjNombres(javax.swing.JLabel jNombres) {
    this.jNombres = jNombres;
  }

  /**
   * @return the jPanelDatos
   */
  public javax.swing.JPanel getjPanelDatos() {
    return jPanelDatos;
  }

  /**
   * @param jPanelDatos the jPanelDatos to set
   */
  public void setjPanelDatos(javax.swing.JPanel jPanelDatos) {
    this.jPanelDatos = jPanelDatos;
  }



  /**
   * @return the jScrollPane1
   */
  public javax.swing.JScrollPane getjScrollPane1() {
    return jScrollPane1;
  }

  /**
   * @param jScrollPane1 the jScrollPane1 to set
   */
  public void setjScrollPane1(javax.swing.JScrollPane jScrollPane1) {
    this.jScrollPane1 = jScrollPane1;
  }

  /**
   * @return the jTelefono
   */
  public javax.swing.JLabel getjTelefono() {
    return jTelefono;
  }

  /**
   * @param jTelefono the jTelefono to set
   */
  public void setjTelefono(javax.swing.JLabel jTelefono) {
    this.jTelefono = jTelefono;
  }

  /**
   * @return the jbuscar
   */
  public javax.swing.JLabel getJbuscar() {
    return jbuscar;
  }

  /**
   * @param jbuscar the jbuscar to set
   */
  public void setJbuscar(javax.swing.JLabel jbuscar) {
    this.jbuscar = jbuscar;
  }

  /**
   * @return the tblEstudiantes
   */
  public javax.swing.JTable getTblEstudiantes() {
    return tblEstudiantes;
  }

  /**
   * @param tblEstudiantes the tblEstudiantes to set
   */
  public void setTblEstudiantes(javax.swing.JTable tblEstudiantes) {
    this.tblEstudiantes = tblEstudiantes;
  }


  /**
   * @return the txtApellidos
   */
  public javax.swing.JTextField getTxtApellidos() {
    return txtApellidos;
  }

  /**
   * @param txtApellidos the txtApellidos to set
   */
  public void setTxtApellidos(javax.swing.JTextField txtApellidos) {
    this.txtApellidos = txtApellidos;
  }

  /**
   * @return the txtBuscar
   */
  public javax.swing.JTextField getTxtBuscar() {
    return txtBuscar;
  }

  /**
   * @param txtBuscar the txtBuscar to set
   */
  public void setTxtBuscar(javax.swing.JTextField txtBuscar) {
    this.txtBuscar = txtBuscar;
  }

  /**
   * @return the txtCorreo
   */
  public javax.swing.JTextField getTxtCorreo() {
    return txtCorreo;
  }

  /**
   * @param txtCorreo the txtCorreo to set
   */
  public void setTxtCorreo(javax.swing.JTextField txtCorreo) {
    this.txtCorreo = txtCorreo;
  }

  /**
   * @return the txtId
   */
  public javax.swing.JTextField getTxtId() {
    return txtId;
  }

  /**
   * @param txtId the txtId to set
   */
  public void setTxtId(javax.swing.JTextField txtId) {
    this.txtId = txtId;
  }

  /**
   * @return the txtMatricula
   */
  public javax.swing.JTextField getTxtMatricula() {
    return txtMatricula;
  }

  /**
   * @param txtMatricula the txtMatricula to set
   */
  public void setTxtMatricula(javax.swing.JTextField txtMatricula) {
    this.txtMatricula = txtMatricula;
  }

  /**
   * @return the txtNombres
   */
  public javax.swing.JTextField getTxtNombres() {
    return txtNombres;
  }

  /**
   * @param txtNombres the txtNombres to set
   */
  public void setTxtNombres(javax.swing.JTextField txtNombres) {
    this.txtNombres = txtNombres;
  }

  /**
   * @return the txtTelefono
   */
  public javax.swing.JTextField getTxtTelefono() {
    return txtTelefono;
  }

  /**
   * @param txtTelefono the txtTelefono to set
   */
  public void setTxtTelefono(javax.swing.JTextField txtTelefono) {
    this.txtTelefono = txtTelefono;
  }

  /**
   * Creates new form Principal
   */
  public Principal() {
    initComponents();
    setLocationRelativeTo(null);
    SetDate();
    //InitContent();
  }
  
  private void InitContent() {
    Principal pl = new Principal(); pl.setSize (1070, 610);
    pl.setLocation (0,0);
    jPanelDatos.removeAll();
    jPanelDatos.add(pl, BorderLayout.CENTER);
    jPanelDatos.revalidate();
    jPanelDatos.repaint ();
 
}
  private void SetDate(){
   
  }
  
  private void ShowJPanel (JPanel p) {
    p.setSize(1070, 610);
    p.setLocation(0,0);
    
    jPanelDatos.removeAll();
    jPanelDatos.add(p, BorderLayout.CENTER);
    jPanelDatos.revalidate();
    jPanelDatos.repaint ();
    
  }

  /**
   * This method is called from within the constructor to initialize the form.
   * WARNING: Do NOT modify this code. The content of this method is always
   * regenerated by the Form Editor.
   */
  @SuppressWarnings("unchecked")
  // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
  private void initComponents() {

    Fondo = new javax.swing.JPanel();
    Menu = new javax.swing.JPanel();
    btnsalir = new javax.swing.JButton();
    btnAcercaDe = new javax.swing.JButton();
    btnPrincipal1 = new javax.swing.JButton();
    btnPersonales = new javax.swing.JButton();
    btnGuiaRapida = new javax.swing.JButton();
    jLabel6 = new javax.swing.JLabel();
    jPanelDatos = new javax.swing.JPanel();
    jMatricula = new javax.swing.JLabel();
    jCorreo = new javax.swing.JLabel();
    jTelefono = new javax.swing.JLabel();
    txtId = new javax.swing.JTextField();
    txtMatricula = new javax.swing.JTextField();
    txtNombres = new javax.swing.JTextField();
    txtApellidos = new javax.swing.JTextField();
    txtCorreo = new javax.swing.JTextField();
    jId = new javax.swing.JLabel();
    txtTelefono = new javax.swing.JTextField();
    jNombres = new javax.swing.JLabel();
    jApellidos = new javax.swing.JLabel();
    btnAgregar = new javax.swing.JButton();
    btnActualizar = new javax.swing.JButton();
    btnBorrar = new javax.swing.JButton();
    jLabel2 = new javax.swing.JLabel();
    jLabel3 = new javax.swing.JLabel();
    jbuscar = new javax.swing.JLabel();
    txtBuscar = new javax.swing.JTextField();
    btnBuscar = new javax.swing.JButton();
    jLabel1 = new javax.swing.JLabel();
    jScrollPane1 = new javax.swing.JScrollPane();
    tblEstudiantes = new javax.swing.JTable();
    Head = new javax.swing.JPanel();
    txtdate = new javax.swing.JLabel();
    btnPerfil = new javax.swing.JButton();

    setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
    setBackground(new java.awt.Color(51, 51, 51));

    Fondo.setBackground(new java.awt.Color(204, 204, 204));
    Fondo.setPreferredSize(new java.awt.Dimension(1366, 768));
    Fondo.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

    Menu.setBackground(new java.awt.Color(255, 255, 255));
    Menu.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.RAISED));
    Menu.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

    btnsalir.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/salir.png"))); // NOI18N
    btnsalir.setText("Salir");
    btnsalir.setBorder(null);
    btnsalir.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnsalir.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
    btnsalir.setIconTextGap(15);
    btnsalir.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnsalirActionPerformed(evt);
      }
    });
    Menu.add(btnsalir, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 610, 250, 40));

    btnAcercaDe.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/acercade.png"))); // NOI18N
    btnAcercaDe.setText("Acerca de");
    btnAcercaDe.setBorder(javax.swing.BorderFactory.createMatteBorder(1, 1, 1, 1, new java.awt.Color(255, 255, 255)));
    btnAcercaDe.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnAcercaDe.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
    btnAcercaDe.setIconTextGap(15);
    btnAcercaDe.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnAcercaDeActionPerformed(evt);
      }
    });
    Menu.add(btnAcercaDe, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 270, 250, 40));

    btnPrincipal1.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/hogar.png"))); // NOI18N
    btnPrincipal1.setText("Principal");
    btnPrincipal1.setBorder(javax.swing.BorderFactory.createMatteBorder(1, 1, 1, 1, new java.awt.Color(255, 255, 255)));
    btnPrincipal1.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnPrincipal1.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
    btnPrincipal1.setIconTextGap(15);
    btnPrincipal1.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnPrincipal1ActionPerformed(evt);
      }
    });
    Menu.add(btnPrincipal1, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 120, 250, 40));

    btnPersonales.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/editar.png"))); // NOI18N
    btnPersonales.setText("Datos personales");
    btnPersonales.setBorder(javax.swing.BorderFactory.createMatteBorder(1, 1, 1, 1, new java.awt.Color(255, 255, 255)));
    btnPersonales.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnPersonales.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
    btnPersonales.setIconTextGap(15);
    btnPersonales.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnPersonalesActionPerformed(evt);
      }
    });
    Menu.add(btnPersonales, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 170, 250, 40));

    btnGuiaRapida.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/guia.png"))); // NOI18N
    btnGuiaRapida.setText("Guia rapida");
    btnGuiaRapida.setBorder(javax.swing.BorderFactory.createMatteBorder(1, 1, 1, 1, new java.awt.Color(255, 255, 255)));
    btnGuiaRapida.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnGuiaRapida.setHorizontalAlignment(javax.swing.SwingConstants.LEFT);
    btnGuiaRapida.setIconTextGap(15);
    btnGuiaRapida.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnGuiaRapidaActionPerformed(evt);
      }
    });
    Menu.add(btnGuiaRapida, new org.netbeans.lib.awtextra.AbsoluteConstraints(10, 220, 250, 40));

    jLabel6.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/SGA.png"))); // NOI18N
    Menu.add(jLabel6, new org.netbeans.lib.awtextra.AbsoluteConstraints(60, 10, 110, 100));

    Fondo.add(Menu, new org.netbeans.lib.awtextra.AbsoluteConstraints(0, -12, 269, 780));

    jPanelDatos.setBackground(new java.awt.Color(255, 255, 255));
    jPanelDatos.setBorder(javax.swing.BorderFactory.createBevelBorder(javax.swing.border.BevelBorder.RAISED));
    jPanelDatos.setFont(new java.awt.Font("Ubuntu", 1, 15)); // NOI18N

    jMatricula.setBackground(new java.awt.Color(0, 0, 0));
    jMatricula.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jMatricula.setText("Matricula");

    jCorreo.setBackground(new java.awt.Color(0, 0, 0));
    jCorreo.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jCorreo.setText("Correo");

    jTelefono.setBackground(new java.awt.Color(0, 0, 0));
    jTelefono.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jTelefono.setText("Telefono");

    txtId.setEditable(false);
    txtId.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    txtId.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        txtIdActionPerformed(evt);
      }
    });

    txtMatricula.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N

    txtNombres.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N

    txtApellidos.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N

    txtCorreo.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N

    jId.setBackground(new java.awt.Color(0, 0, 0));
    jId.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jId.setText("Id");

    txtTelefono.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N

    jNombres.setBackground(new java.awt.Color(0, 0, 0));
    jNombres.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jNombres.setText("Nombres");

    jApellidos.setBackground(new java.awt.Color(0, 0, 0));
    jApellidos.setFont(new java.awt.Font("Ubuntu", 0, 18)); // NOI18N
    jApellidos.setText("Apellidos");

    btnAgregar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    btnAgregar.setText("Agregar");
    btnAgregar.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnAgregar.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnAgregarActionPerformed(evt);
      }
    });

    btnActualizar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    btnActualizar.setText("Actualizar");
    btnActualizar.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));

    btnBorrar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    btnBorrar.setText("Borrar");
    btnBorrar.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnBorrar.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnBorrarActionPerformed(evt);
      }
    });

    jLabel2.setBackground(new java.awt.Color(0, 0, 0));
    jLabel2.setFont(new java.awt.Font("Ubuntu", 1, 15)); // NOI18N
    jLabel2.setText("Formulario del estudiante");

    jLabel3.setBackground(new java.awt.Color(0, 0, 0));
    jLabel3.setFont(new java.awt.Font("Ubuntu", 1, 15)); // NOI18N
    jLabel3.setText("Tabla de contenido");

    jbuscar.setBackground(new java.awt.Color(0, 0, 0));
    jbuscar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    jbuscar.setText("Buscar");

    txtBuscar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    txtBuscar.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        txtBuscarActionPerformed(evt);
      }
    });

    btnBuscar.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    btnBuscar.setText("Refrescar");
    btnBuscar.setCursor(new java.awt.Cursor(java.awt.Cursor.HAND_CURSOR));
    btnBuscar.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnBuscarActionPerformed(evt);
      }
    });

    jLabel1.setBackground(new java.awt.Color(0, 0, 0));
    jLabel1.setFont(new java.awt.Font("Ubuntu", 0, 15)); // NOI18N
    jLabel1.setText("*Selecionar un estudiante para actualizar, borrar o ampliar");

    tblEstudiantes.setBackground(new java.awt.Color(102, 0, 102));
    tblEstudiantes.setFont(new java.awt.Font("Ubuntu", 0, 12)); // NOI18N
    tblEstudiantes.setForeground(new java.awt.Color(255, 255, 255));
    tblEstudiantes.setModel(new javax.swing.table.DefaultTableModel(
      new Object [][] {

      },
      new String [] {

      }
    ));
    tblEstudiantes.setGridColor(new java.awt.Color(255, 255, 255));
    tblEstudiantes.setSelectionBackground(new java.awt.Color(51, 0, 51));
    tblEstudiantes.setSelectionForeground(new java.awt.Color(255, 255, 255));
    jScrollPane1.setViewportView(tblEstudiantes);
    tblEstudiantes.getAccessibleContext().setAccessibleName("Tabla de mostrar cloentes");

    javax.swing.GroupLayout jPanelDatosLayout = new javax.swing.GroupLayout(jPanelDatos);
    jPanelDatos.setLayout(jPanelDatosLayout);
    jPanelDatosLayout.setHorizontalGroup(
      jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
      .addGroup(jPanelDatosLayout.createSequentialGroup()
        .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(20, 20, 20)
            .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 198, javax.swing.GroupLayout.PREFERRED_SIZE))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(70, 70, 70)
            .addComponent(jId)
            .addGap(24, 24, 24)
            .addComponent(txtId, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE)
            .addGap(18, 18, 18)
            .addComponent(jMatricula)
            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
            .addComponent(txtMatricula, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE)
            .addGap(45, 45, 45)
            .addComponent(jNombres)
            .addGap(6, 6, 6)
            .addComponent(txtNombres, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(20, 20, 20)
            .addComponent(jLabel3))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(20, 20, 20)
            .addComponent(jbuscar)
            .addGap(22, 22, 22)
            .addComponent(txtBuscar, javax.swing.GroupLayout.PREFERRED_SIZE, 284, javax.swing.GroupLayout.PREFERRED_SIZE)
            .addGap(6, 6, 6)
            .addComponent(btnBuscar))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(20, 20, 20)
            .addComponent(jLabel1))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(20, 20, 20)
            .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 799, javax.swing.GroupLayout.PREFERRED_SIZE))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
              .addGroup(jPanelDatosLayout.createSequentialGroup()
                .addGap(28, 28, 28)
                .addComponent(jApellidos)
                .addGap(7, 7, 7)
                .addComponent(txtApellidos, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(31, 31, 31)
                .addComponent(jCorreo))
              .addGroup(jPanelDatosLayout.createSequentialGroup()
                .addGap(94, 94, 94)
                .addComponent(btnAgregar, javax.swing.GroupLayout.PREFERRED_SIZE, 98, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(36, 36, 36)
                .addComponent(btnBorrar, javax.swing.GroupLayout.PREFERRED_SIZE, 98, javax.swing.GroupLayout.PREFERRED_SIZE)))
            .addGap(11, 11, 11)
            .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
              .addComponent(btnActualizar)
              .addGroup(jPanelDatosLayout.createSequentialGroup()
                .addComponent(txtCorreo, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(51, 51, 51)
                .addComponent(jTelefono)
                .addGap(6, 6, 6)
                .addComponent(txtTelefono, javax.swing.GroupLayout.PREFERRED_SIZE, 169, javax.swing.GroupLayout.PREFERRED_SIZE)))))
        .addGap(222, 222, 222))
    );
    jPanelDatosLayout.setVerticalGroup(
      jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
      .addGroup(jPanelDatosLayout.createSequentialGroup()
        .addGap(30, 30, 30)
        .addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 28, javax.swing.GroupLayout.PREFERRED_SIZE)
        .addGap(20, 20, 20)
        .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(2, 2, 2)
            .addComponent(jId))
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(5, 5, 5)
            .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
              .addComponent(jMatricula)
              .addComponent(txtId, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
              .addComponent(txtMatricula, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
          .addComponent(jNombres)
          .addComponent(txtNombres, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
        .addGap(41, 41, 41)
        .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
          .addComponent(jApellidos)
          .addComponent(txtApellidos, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
          .addComponent(jCorreo)
          .addComponent(txtCorreo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
          .addComponent(jTelefono)
          .addComponent(txtTelefono, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
        .addGap(40, 40, 40)
        .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
          .addComponent(btnBorrar)
          .addComponent(btnActualizar)
          .addComponent(btnAgregar))
        .addGap(38, 38, 38)
        .addComponent(jLabel3)
        .addGap(2, 2, 2)
        .addGroup(jPanelDatosLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
          .addGroup(jPanelDatosLayout.createSequentialGroup()
            .addGap(10, 10, 10)
            .addComponent(jbuscar))
          .addComponent(txtBuscar, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
          .addComponent(btnBuscar))
        .addGap(2, 2, 2)
        .addComponent(jLabel1)
        .addGap(18, 18, 18)
        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 216, javax.swing.GroupLayout.PREFERRED_SIZE)
        .addContainerGap())
    );

    Fondo.add(jPanelDatos, new org.netbeans.lib.awtextra.AbsoluteConstraints(280, 80, 1070, 640));

    Head.setBackground(new java.awt.Color(255, 255, 255));
    Head.setBorder(new javax.swing.border.SoftBevelBorder(javax.swing.border.BevelBorder.RAISED));
    Head.setLayout(new org.netbeans.lib.awtextra.AbsoluteLayout());

    txtdate.setFont(new java.awt.Font("Ubuntu", 0, 14)); // NOI18N
    txtdate.setText("Hoy es Lunes del 11 de Diciembre del 2023");
    Head.add(txtdate, new org.netbeans.lib.awtextra.AbsoluteConstraints(20, 10, 280, 60));

    btnPerfil.setIcon(new javax.swing.ImageIcon(getClass().getResource("/vista/imagenes/perfil.png"))); // NOI18N
    btnPerfil.setText("Perfil");
    btnPerfil.setBorder(null);
    btnPerfil.setHorizontalTextPosition(javax.swing.SwingConstants.LEFT);
    btnPerfil.setIconTextGap(10);
    btnPerfil.addActionListener(new java.awt.event.ActionListener() {
      public void actionPerformed(java.awt.event.ActionEvent evt) {
        btnPerfilActionPerformed(evt);
      }
    });
    Head.add(btnPerfil, new org.netbeans.lib.awtextra.AbsoluteConstraints(960, 20, -1, -1));

    Fondo.add(Head, new org.netbeans.lib.awtextra.AbsoluteConstraints(268, -8, 1100, 80));

    javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
    getContentPane().setLayout(layout);
    layout.setHorizontalGroup(
      layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
      .addComponent(Fondo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
    );
    layout.setVerticalGroup(
      layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
      .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
        .addComponent(Fondo, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
        .addGap(0, 0, Short.MAX_VALUE))
    );

    pack();
  }// </editor-fold>//GEN-END:initComponents

  private void txtIdActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtIdActionPerformed
    // TODO add your handling code here:
  }//GEN-LAST:event_txtIdActionPerformed

  private void btnBorrarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBorrarActionPerformed
    // TODO add your handling code here:
  }//GEN-LAST:event_btnBorrarActionPerformed

  private void txtBuscarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_txtBuscarActionPerformed
    // TODO add your handling code here:
  }//GEN-LAST:event_txtBuscarActionPerformed

  private void btnAgregarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAgregarActionPerformed
    // TODO add your handling code here:
  }//GEN-LAST:event_btnAgregarActionPerformed

  private void btnBuscarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnBuscarActionPerformed
     
  }//GEN-LAST:event_btnBuscarActionPerformed

  private void btnsalirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnsalirActionPerformed
    System.exit(0);
  }//GEN-LAST:event_btnsalirActionPerformed

  private void btnAcercaDeActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnAcercaDeActionPerformed
    ShowJPanel(new AcercaDe());
  }//GEN-LAST:event_btnAcercaDeActionPerformed

  private void btnPrincipal1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnPrincipal1ActionPerformed

    Principal vistaPrincipal = new Principal();
    ControladorEstudiante controladorEstudiante = new ControladorEstudiante(vistaPrincipal);
//    this.dispose(); // Cierra la ventana actual
//    new Principal().setVisible(true); 
  }//GEN-LAST:event_btnPrincipal1ActionPerformed

  private void btnPersonalesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnPersonalesActionPerformed
    DatosPersonales vistaDatosPersonales = new DatosPersonales();
    PersonalesDAO personalesDAO = new PersonalesDAO();
    ControladorPersonales controladorPersonales = new ControladorPersonales(vistaDatosPersonales);

    ShowJPanel(vistaDatosPersonales);
    vistaDatosPersonales.setVisible(true);
    controladorPersonales.setVistaDatosPersonales(vistaDatosPersonales); 
  }//GEN-LAST:event_btnPersonalesActionPerformed

  private void btnGuiaRapidaActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnGuiaRapidaActionPerformed
 
    ShowJPanel(new GuiaRapida());

  }//GEN-LAST:event_btnGuiaRapidaActionPerformed

  private void btnPerfilActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnPerfilActionPerformed
    ShowJPanel(new Perfil());
  }//GEN-LAST:event_btnPerfilActionPerformed

  

  // Variables declaration - do not modify//GEN-BEGIN:variables
  private javax.swing.JPanel Fondo;
  private javax.swing.JPanel Head;
  private javax.swing.JPanel Menu;
  private javax.swing.JButton btnAcercaDe;
  private javax.swing.JButton btnActualizar;
  private javax.swing.JButton btnAgregar;
  private javax.swing.JButton btnBorrar;
  private javax.swing.JButton btnBuscar;
  private javax.swing.JButton btnGuiaRapida;
  private javax.swing.JButton btnPerfil;
  private javax.swing.JButton btnPersonales;
  private javax.swing.JButton btnPrincipal1;
  private javax.swing.JButton btnsalir;
  private javax.swing.JLabel jApellidos;
  private javax.swing.JLabel jCorreo;
  private javax.swing.JLabel jId;
  private javax.swing.JLabel jLabel1;
  private javax.swing.JLabel jLabel2;
  private javax.swing.JLabel jLabel3;
  private javax.swing.JLabel jLabel6;
  private javax.swing.JLabel jMatricula;
  private javax.swing.JLabel jNombres;
  private javax.swing.JPanel jPanelDatos;
  private javax.swing.JScrollPane jScrollPane1;
  private javax.swing.JLabel jTelefono;
  private javax.swing.JLabel jbuscar;
  private javax.swing.JTable tblEstudiantes;
  private javax.swing.JTextField txtApellidos;
  private javax.swing.JTextField txtBuscar;
  private javax.swing.JTextField txtCorreo;
  private javax.swing.JTextField txtId;
  private javax.swing.JTextField txtMatricula;
  private javax.swing.JTextField txtNombres;
  private javax.swing.JTextField txtTelefono;
  private javax.swing.JLabel txtdate;
  // End of variables declaration//GEN-END:variables

  /**
 * Agregar Getters
 * @author bourdier
 */
  
  
}

