using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SQLitePCL;

using EMMapp.Models;

namespace EMMapp.Services;

public class CertificateService
{
    public byte[] GenerateCertificate(String hisName, String herName, String lastName)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create( container =>
        {
            container.Page(page =>
            {

                page.Margin(50);
                page.Content()
                    .Column(col =>
                    {
                        col.Spacing(25);

                    col.Item()
                    .AlignCenter()
                    .Text("Certificado de Completacion")
                    .FontSize(30)
                    .Bold();

                    col.Item()
                    .AlignCenter()
                    .Text("Esto certifica que ")
                    .FontSize(18);

                    col.Item()
                    .AlignCenter()
                    .Text(String.Concat(hisName," ","❤️"," ", herName))
                    .FontSize(28)
                    .Bold();

                    col.Item()
                    .AlignCenter()
                    .Text(lastName)
                    .FontSize(28)
                    .Bold();

                    col.Item()
                    .AlignCenter()
                    .Text("Completaron la Experiencia del Fin De Semana en:")
                    .FontSize(18);

                    col.Item()
                    .AlignCenter()
                    .Text("Junio 12, 13 y 14 del 2026")
                    .FontSize(18)
                    .Bold();
                });
         });
    });

    return document.GeneratePdf();
    }

    public byte[] GenerateAllCertificates(IEnumerable<Registration> registrations)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            foreach(var registration in registrations)
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Content()
                        .Column(col =>
                        {
                            col.Spacing(25);

                            col.Item()
                            .AlignCenter()
                            .Text("Certificado de Completacion")
                            .FontSize(30)
                            .Bold();

                            col.Item()
                            .AlignCenter()
                            .Text("Esto certifica que ")
                            .FontSize(18);

                            col.Item()
                            .AlignCenter()
                            .Text(String.Concat(registration.hisName," ","❤️"," ", registration.herName))
                            .FontSize(28)
                            .Bold();

                            col.Item()
                            .AlignCenter()
                            .Text(registration.lastName)
                            .FontSize(28)
                            .Bold();

                            col.Item()
                            .AlignCenter()
                            .Text("Completaron la Experiencia del Fin De Semana en:")
                            .FontSize(18);

                            col.Item()
                            .AlignCenter()
                            .Text("Junio 12, 13 y 14 del 2026")
                            .FontSize(18)
                            .Bold();
                        });
                });
            }
        });

        return document.GeneratePdf();
    }


    public byte[] GenerateTableTent(String hisName, String herName, String lastName)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.Letter.Landscape());

                page.Margin(20);

                page.Content().Column(column =>
                {
                    column.Item().Height(250).AlignCenter().AlignMiddle()
                    .Column(c =>
                    {
                        c.Item()
                        .AlignCenter()
                        .Text(String.Concat(hisName, " ❤️ ", herName))
                        .FontSize(32)
                        .Bold();

                        c.Item()
                        .AlignCenter()
                        .Text(lastName)
                        .FontSize(32)
                        .Bold();


                    });

                    column.Item()
                    .BorderTop(1);

                    column.Item().Height(250).AlignCenter().AlignMiddle()
                    .Column(c =>
                    {
                        c.Item()
                        .AlignCenter()
                        .Text(String.Concat(hisName, " ❤️ ", herName))
                        .FontSize(32)
                        .Bold();

                        c.Item()
                        .AlignCenter()
                        .Text(lastName)
                        .FontSize(32)
                        .Bold();


                    });



                });
            });
        });

        return document.GeneratePdf();
    }

    public byte[] GenerateAllTableTents(IEnumerable<Registration> registrations)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var document = Document.Create(container =>
        {
            foreach(var registration in registrations)
            {
                container.Page(page =>
                {
                page.Size(PageSizes.Letter.Landscape());

                page.Margin(20);

                page.Content().Column(column =>
                {
                    column.Item().Height(250).AlignCenter().AlignMiddle()
                    .Column(c =>
                    {
                        c.Item()
                        .AlignCenter()
                        .Text(String.Concat(registration.hisName, " ❤️ ", registration.herName))
                        .FontSize(32)
                        .Bold();

                        c.Item()
                        .AlignCenter()
                        .Text(registration.lastName)
                        .FontSize(32)
                        .Bold();


                    });

                    column.Item()
                    .BorderTop(1);

                    column.Item().Height(250).AlignCenter().AlignMiddle()
                    .Column(c =>
                    {
                        c.Item()
                        .AlignCenter()
                        .Text(String.Concat(registration.hisName, " ❤️ ", registration.herName))
                        .FontSize(32)
                        .Bold();

                        c.Item()
                        .AlignCenter()
                        .Text(registration.lastName)
                        .FontSize(32)
                        .Bold();


                    });



                });
            });
            }
        });

        return document.GeneratePdf();
    }
}
