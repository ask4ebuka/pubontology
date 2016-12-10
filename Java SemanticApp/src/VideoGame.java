import java.awt.EventQueue;

import javax.swing.JFrame;
import org.apache.jena.query.* ;
import org.apache.jena.sparql.engine.http.QueryEngineHTTP ;
import java.awt.Color;
import javax.swing.JButton;
import java.awt.Font;
import java.awt.Panel;
import java.awt.SystemColor;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JPanel;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;
import javax.swing.border.BevelBorder;
public class VideoGame {
DefaultTableModel model;
	private JFrame frame;
	private JTable table;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					VideoGame window = new VideoGame();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public VideoGame() {
		initialize();
		
		String queryStr = "select  * where {?s a ?Class} LIMIT 10";
		QueryProcessor.processor("3030", "one", queryStr);
		
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.getContentPane().setFont(new Font("Yu Gothic UI Semibold", Font.PLAIN, 18));
		frame.getContentPane().setForeground(new Color(0, 128, 0));
		frame.getContentPane().setBackground(new Color(0, 0, 51));
		frame.getContentPane().setLayout(null);
		
		JMenuBar menuBar = new JMenuBar();
		menuBar.setBounds(0, 0, 473, 21);
		frame.getContentPane().add(menuBar);
		
		JMenu mnNewMenu = new JMenu("Menu");
		menuBar.add(mnNewMenu);
		
		JMenuItem mntmExit = new JMenuItem("Exit");
		mntmExit.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
			System.	exit(0);
			}
		});
		
		JMenuItem mntmClosePanel = new JMenuItem("Close Panel");
		mnNewMenu.add(mntmClosePanel);
		mnNewMenu.add(mntmExit);
		
		JMenu mnNewMenu_1 = new JMenu("Creator List");
		menuBar.add(mnNewMenu_1);
		
		JMenuItem mntmComposer = new JMenuItem("Composer");
		mntmComposer.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				
			}
		});
		mnNewMenu_1.add(mntmComposer);
		
		JMenuItem mntmDesigner = new JMenuItem("Designer");
		mnNewMenu_1.add(mntmDesigner);
		
		JMenuItem mntmWriter = new JMenuItem("Writer");
		mnNewMenu_1.add(mntmWriter);
		
		JMenuItem mntmProgrammer = new JMenuItem("Programmer");
		mnNewMenu_1.add(mntmProgrammer);
		
		JMenuItem mntmProducer = new JMenuItem("Producer");
		mnNewMenu_1.add(mntmProducer);
		
		JMenuItem mntmArtist = new JMenuItem("Artist");
		mnNewMenu_1.add(mntmArtist);
		
		JMenuItem mntmDirector = new JMenuItem("Director");
		mnNewMenu_1.add(mntmDirector);
		
		JPanel panel = new JPanel();
		panel.setBounds(0, 22, 463, 256);
		frame.getContentPane().add(panel);
		panel.setLayout(null);
		
		table = new JTable();
		table.setBorder(new BevelBorder(BevelBorder.LOWERED, null, null, null, null));
		table.setBounds(37, 11, 443, 220);
		panel.add(table);
		frame.setBounds(100, 100, 489, 317);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		model = (DefaultTableModel) JTable.getModel();
			
	}
	
	
		
	
}
