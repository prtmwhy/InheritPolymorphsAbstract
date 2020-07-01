using System;
using System.Collections.Generic;
using System.Threading;

namespace tugasgabungan2{
    class Program{

        static void Main(string[] args){
          
            List<Karyawan> karyawan = new List<Karyawan>();
            Menu(karyawan);
        }

        static void Menu(List<Karyawan> karyawan){
            bool status = true;

            do{
                Console.Clear();
                Console.WriteLine("========== SELAMAT DATANG ===========");
                Console.WriteLine("=====================================");
                Console.WriteLine("");
                Console.WriteLine("Silahkan Pilih Menu Aplikasi: ");
                Console.WriteLine("1. Tambah Data\n2. Hapus Data \n3. Tampilkan Data \n4. Keluar");
                Console.WriteLine("");

            InvalidOption:
                string pil;
                Console.Write("Masukkan Pilihan [1-4]: ");
                pil = Console.ReadLine();

                if (pil == "1"){
                    TambahData(karyawan);
                    BalikMenu();
                }else if (pil== "2"){
                   
                    HapusData(karyawan);
                    BalikMenu();
                }else if (pil == "3"){
                   
                    TampilkanData(karyawan);
                    BalikMenu();
                }else if (pil == "4"){
                    
                    Console.WriteLine("Terima Kasih ");
                    Thread.Sleep(200);
                    status = false;
                }else{
                    Console.WriteLine("Pilihan tidak ada, silahkan masukkan lagi");
                    goto InvalidOption;
                }
            } while (status);
        }

        static void TambahData(List<Karyawan> karyawan){
           
            Console.Clear();
            Console.WriteLine("========== TAMBAH KARYAWAN ==========");
            Console.WriteLine("=====================================");
            Console.WriteLine("\nSilahkan Pilih Jenis Karyawan: ");
            Console.WriteLine("1. Karyawan Tetap \n2. Karyawan Harian \n3. Sales");

        InvalidOption:
            string pil;
            Console.Write("Masukkan Pilihan [1-3]: ");
            pil = Console.ReadLine();
            Console.WriteLine();

            if (pil == "1"){
                KaryawanTetap karyawanTetap = new KaryawanTetap();
                Console.WriteLine("Tambah Karyawan Tetap");
                Console.Write("Masukkan NIK \t\t: ");
                karyawanTetap.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                karyawanTetap.Nama = Console.ReadLine();

                Console.Write("Masukkan Gaji Bulanan \t: ");
                karyawanTetap.GajiBulanan = Convert.ToDouble(Console.ReadLine());

                karyawan.Add(karyawanTetap);

            }else if (pil == "2"){
               
                KaryawanHarian karyawanHarian = new KaryawanHarian();


                Console.WriteLine("Tambah Karyawan Harian");

                
                Console.Write("Masukkan NIK \t\t: ");
                karyawanHarian.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                karyawanHarian.Nama = Console.ReadLine();

                Console.Write("Masukkan Upah per Jam \t: ");
                karyawanHarian.UpahPerJam = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Jam Kerja \t: ");
                karyawanHarian.JumlahJamKerja = Convert.ToDouble(Console.ReadLine());

              
                karyawan.Add(karyawanHarian);

            }else if (pil == "3"){
               
                Sales sales = new Sales();

                Console.WriteLine("Tambah Karyawan Harian");

                
                Console.Write("Masukkan NIK \t\t: ");
                sales.NIK = Console.ReadLine();

                Console.Write("Masukkan Nama \t\t: ");
                sales.Nama = Console.ReadLine();

                Console.Write("Masukkan Jml Penjualan \t: ");
                sales.JumlahPenjualan = Convert.ToDouble(Console.ReadLine());

                Console.Write("Masukkan Komisi \t: ");
                sales.Komisi = Convert.ToDouble(Console.ReadLine());

                
                karyawan.Add(sales);
            }else{
                
                Console.WriteLine("Pilihan tidak ada, silahkan masukkan lagi");
                goto InvalidOption;
            }
        }

        static void HapusData(List<Karyawan> karyawan){
           
            Console.Clear();

          
            Console.WriteLine("======== HAPUS DATA KARYAWAN ========");
            Console.WriteLine("=====================================");

            bool found = true;

            string nik;
            Console.Write("\nMasukkan NIK Karyawan: ");
            nik = Console.ReadLine();

           
            for (int i = 0; i < karyawan.Count; i++){
                if (karyawan[i].NIK == nik){
                  
                    karyawan.Remove(karyawan[i]);
                    found = true;
                    break;
                }else{
                    
                    found = false;
                }
            }

            if (!found){
                Console.WriteLine("Data dengan NIK = {0} tidak ditemukan", nik);
            }else{
                Console.WriteLine("Data dengan NIK = {0} berhasil dihapus", nik);
            }
        }

        static void TampilkanData(List<Karyawan> karyawan){

            Console.Clear();

            Console.WriteLine("==================================================");
            Console.WriteLine(" NO | NIK / NAMA\t\t | Gaji\t\t |");
            Console.WriteLine("==================================================");
            for (int i = 0; i < karyawan.Count; i++){

                Console.WriteLine(" {0}. | {1} {2} \t\t | {3} \t |", i + 1, karyawan[i].NIK, karyawan[i].Nama, karyawan[i].Gaji());
            }
        }

        static void BalikMenu(){
            Console.WriteLine("Tekan Tombol Apapun Untuk Keluar ^^");
            Console.ReadKey();
        }
    }
    
    public abstract class Karyawan{
        public string NIK;
        public string Nama;
        public abstract double Gaji();
    }
    
    public class KaryawanTetap : Karyawan{

        public double GajiBulanan;
        public override double Gaji(){
            return this.GajiBulanan;
        }
    }
    
    public class KaryawanHarian : Karyawan{
        public double UpahPerJam;
        public double JumlahJamKerja;
        public override double Gaji(){
            return this.UpahPerJam * this.JumlahJamKerja;
        }
    }
    
    public class Sales : Karyawan{
        public double JumlahPenjualan;
        public double Komisi;
        public override double Gaji(){
            return this.JumlahPenjualan * this.Komisi;
        }
    }
}