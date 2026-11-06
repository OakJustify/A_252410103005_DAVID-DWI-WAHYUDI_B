using System;
using System.Collections.Generic;

class GalonAkua : ProdukGalon
{
    public GalonAkua(string idProduk, string namaProduk, int stokGudang) : base(idProduk, namaProduk, stokGudang)
    {
    }

    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 20000;
    }
}

class GalonBerkeran : ProdukGalon
{
    public GalonBerkeran(string idProduk, string namaProduk, int stokGudang) : base(idProduk, namaProduk, stokGudang)
    {
    }

    public override int HitungBiaya(int jumlah)
    {
        return jumlah * 12000;
    }
}

class Agen
{
    private string idAgen;
    private string namaAgen;
    private int stokAgen;

    public Agen(string idAgen, string namaAgen, int stokAgen)
    {
        this.idAgen = idAgen;
        this.namaAgen = namaAgen;
        this.stokAgen = stokAgen;
    }

    public void TampilInfo()
    {
        Console.WriteLine("ID Agen: " + idAgen);
        Console.WriteLine("Nama Agen: " + namaAgen);
        Console.WriteLine("Stok Agen: " + stokAgen);
    }
}

class ProdukGalon
{
    private string idProduk;
    private string namaProduk;
    private int stokGudang;

    public ProdukGalon(string idProduk, string namaProduk, int stokGudang)
    {
        this.idProduk = idProduk;
        this.namaProduk = namaProduk;
        this.stokGudang = stokGudang;
    }

    public int StokGudang
    {
        get { return stokGudang; }
        set
        {
            if (value < 0)
            {
                stokGudang = 0;
            }
            else
            {
                stokGudang = value;
            }
        }
    }

    public void KurangiStok(int jumlah)
    {
        stokGudang -= jumlah;
    }
}

class DistribusiGalon : DapatDidistribusikan
{
    private Agen agenTujuan;
    private ProdukGalon produkGalon;
    private int jumlah;

    public DistribusiGalon(Agen agenTujuan, ProdukGalon produkGalon, int jumlah)
    {
        this.agenTujuan = agenTujuan;
        this.produkGalon = produkGalon;
        this.jumlah = jumlah;
    }

    public void KirimPaket()
    {
        if (jumlah > 0 && jumlah <= produkGalon.StokGudang)
        {
            produkGalon.StokGudang -= jumlah;
            agenTujuan.StokAgen += jumlah;
            Console.WriteLine("Paket berhasil dikirimkan ke agen " + agenTujuan.namaAgen);
        }
        else
        {
            Console.WriteLine("Kiriman gagal. Alasan: Jumlah melebihi stok atau kurang dari 1.");
        }
    }
}

class DapatDidistribusikan
{
    public virtual void KirimPaket()
    {
        throw new NotImplementedException();
    }
}

class SindikatGalon
{
    private List<Agen> agen;
    private List<ProdukGalon> produk;

    public SindikatGalon()
    {
        agen = new List<Agen>();
        produk = new List<ProdukGalon>();
    }

    public void TambahAgen(Agen agen)
    {
        this.agen.Add(agen);
    }

    public void TambahProduk(ProdukGalon produk)
    {
        this.produk.Add(produk);
    }

    public void TampilkanSindikat()
    {
      Console.WriteLine("FAK PBO");
    }
}

class Program
{
    static void Main()
    {
        SindikatGalon sindikat = new SindikatGalon();

        // menambahkan agen
        Agen agen1 = new Agen("A001", "Agen 1", 100);
        sindikat.TambahAgen(agen1);

        Agen agen2 = new Agen("A002", "Agen 2", 200);
        sindikat.TambahAgen(agen2);

        // methodenambahkan produk
        ProdukGalon produk1 = new GalonAkua("P001", "Air Galon Akua", 150);
        ProdukGalon produk2 = new GalonBerkeran("P002", "Air Galon Berkeran", 200);
        sindikat.TambahProduk(produk1);
        sindikat.TambahProduk(produk2);

        // menampilkan sindikat
        sindikat.TampilkanSindikat();

        // distribusi produk
        DistribusiGalon distribusi1 = new DistribusiGalon(agen1, produk1, 50);
        distribusi1.KirimPaket();

        DistribusiGalon distribusi2 = new DistribusiGalon(agen2, produk2, 100);
        distribusi2.KirimPaket();

        // menampilkan akhir stok
        sindikat.TampilkanSindikat();
    }
}

// PBO KONTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO...............................................HOAKK
