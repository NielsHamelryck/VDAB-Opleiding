package LaboKlassenVoorbeeld01;

import java.util.*;

/**
 * The LabClass class represents an enrolment list for one lab class. It stores
 * the time, room and participants of the lab, as well as the instructor's name.
 * 
 * @author Michael Kölling and David Barnes
 * @version 2011.07.31
 */
public class LaboKlas
{
    private String instructor;
    private String room;
    private String timeAndDay;
    private ArrayList<Student> students;
    private int capacity;
    
    /**
     * Create a LabClass with a maximum number of enrolments. All other details
     * are set to default values.
     */
    public LaboKlas(int maxNumberOfStudents)
    {
        instructor = "unknown";
        room = "unknown";
        timeAndDay = "unknown";
        students = new ArrayList<Student>();
        capacity = maxNumberOfStudents;
    }

    /**
     * Add a student to this LabClass.
     */
    public void inschrijvenStudent(Student newStudent)
    {
        if(students.size() == capacity) {
            System.out.println("The class is full, you cannot enrol.");
        }
        else {
            students.add(newStudent);
        }
    }
    
    /**
     * Return the number of students currently enrolled in this LabClass.
     */
    public int aantalStudenten()
    {
        return students.size();
    }
    
    /**
     * Set the room number for this LabClass.
     */
    public void bepaalLokaal(String roomNumber)
    {
        room = roomNumber;
    }
    
    /**
     * Set the time for this LabClass. The parameter should define the day
     * and the time of day, such as "Friday, 10am".
     */
    public void bepaalTijd(String timeAndDayString)
    {
        timeAndDay = timeAndDayString;
    }
    
    /**
     * Set the name of the instructor for this LabClass.
     */
    public void bepaalInstructeur(String instructorName)
    {
        instructor = instructorName;
    }
    
    /**
     * Print out a class list with other LabClass details to the standard
     * terminal.
     */
    public void printLijst()
    {
        System.out.println("Labo klas " + timeAndDay);
        System.out.println("Instructeur: " + instructor + "   Lokaal: " + room);
        System.out.println("Klaslijst:");
        for(Student student : students) {
            student.print();
        }
        System.out.println("Aantal studenten: " + aantalStudenten());
    }
}
