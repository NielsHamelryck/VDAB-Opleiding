package BankVoorbeeld02;

import java.util.Date;
import java.text.*;
import java.util.GregorianCalendar;
/**
 * Write a description of class SpaarRekening here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class SpaarRekening
{
    private String rekeningNummer;
    private double saldo;
    private static double intrest;

    /**
     * Constructor for objects of class SpaarRekening
     */
    public SpaarRekening(String mijnRekeningNummer, double mijnSaldo)
    {
        rekeningNummer = mijnRekeningNummer;
        saldo = mijnSaldo;
    }
    
    public void storten(double bedrag){
        if (bedrag > 0){
            saldo += bedrag;
        } else {
            System.out.println("U kunt geen negatief bedrag storten!");
        }
    }
    
    public void afhalen(double bedrag){
        if (bedrag <= saldo) {
            saldo -= bedrag;
        } else {
            System.out.println("U saldo is ontoereikend! Saldo: " + saldo + ", bedrag: " + bedrag);
        }
    }
    
    public void overschrijven(String naarRekeningNummer, double bedrag){
        if (bedrag <= saldo){
            System.out.println("Het bedrag " + bedrag + " zal overgeschreven worden op rekeningnr " + naarRekeningNummer);
        }
        afhalen(bedrag);
    }
    
    public void overschrijven(String naarRekeningNummer, double bedrag, int jaar, int maand, int dag){
        GregorianCalendar kalender = new GregorianCalendar(jaar, maand, dag);
        Date datum = kalender.getTime();
        if (bedrag <= saldo){
            System.out.println("Het bedrag " + bedrag + " zal op datum " + datum + " overgeschreven worden op rekeningnr " + naarRekeningNummer);
        }
        afhalen(bedrag);
    }
    
    public double getSaldo(){
        return saldo;
    }
    
    public String getRekeningNummer(){
        return rekeningNummer;
    }
    
    public static double getIntrest(){
        return SpaarRekening.intrest;
    }
    
    public static void setIntrest(double mijnIntrest){
        SpaarRekening.intrest = mijnIntrest;
    }
}
