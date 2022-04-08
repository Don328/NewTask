using NewTask.Core.Models;
using NewTask.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask.Core.Data
{
    internal class Seed
    {
        private readonly InMemDbContext inMem;

        internal Seed(InMemDbContext inMem)
        {
            this.inMem = inMem;

            if (!inMem.Opera.Any())
            {
                SeedOpera();
            }

            if (!inMem.Notas.Any())
            {
                SeedNotas();
            }
        }

        private void SeedOpera()
        {
            var opera = new List<_Opus>();

            var opus1 = CreateOpus("Task 1");
            opus1.Status = OpusStatus.New;

            var opus2 = CreateOpus("Task 2");
            opus2.Status = OpusStatus.Active;

            var opus3 = CreateOpus("Task 3");
            opus3.Status = OpusStatus.Active;

            var opus4 = CreateOpus("Task 4");
            opus4.Status = OpusStatus.Pending;

            var opus5 = CreateOpus("Task 5");
            opus5.Status = OpusStatus.Completed;

            var opus6 = CreateOpus("Task 6");
            opus6.Status = OpusStatus.Pending;

            var opus7 = CreateOpus("Task 7");
            opus7.Status = OpusStatus.Active;

            var opus8 = CreateOpus("Task 8");
            opus8.Status = OpusStatus.New;

            var opus9 = CreateOpus("Task 9");
            opus9.Status = OpusStatus.Completed;

            var opus10 = CreateOpus("Task 10");
            opus10.Status = OpusStatus.Active;

            opera.Add(opus1);
            opera.Add(opus2);
            opera.Add(opus3);
            opera.Add(opus4);
            opera.Add(opus5);
            opera.Add(opus6);
            opera.Add(opus7);
            opera.Add(opus8);
            opera.Add(opus9);
            opera.Add(opus10);

            inMem.Opera.AddRange(opera);
        }

        private _Opus CreateOpus(string title)
        {
            var opus = new _Opus
            {
                Title = title,
                Status = OpusStatus.New
            };

            return opus;
        }

        private void SeedNotas()
        {
            var notas = new List<_Nota>();

            var nota1 = CreateNota(
                "Get Started",
                "Let's do this task right away.",
                2);

            var nota2 = CreateNota(
                "This is a priority",
                "This task needs to be completed soon",
                3);

            var nota3 = CreateNota(
                "We need to get this done",
                "What is holding this up???",
                3);

            var nota4 = CreateNota(
                "Waiting on approval",
                "This task is pending approval",
                4);

            var nota5 = CreateNota(
                "Let's do this",
                "This one should be easy",
                5);

            var nota6 = CreateNota(
                "Completed",
                "That was easy",
                5);

            var nota7 = CreateNota(
                "This one can wait",
                "Pending...",
                6);

            var nota8 = CreateNota(
                "This task should be active",
                "Keep this one going",
                7);

            var nota9 = CreateNota(
                "Pretty good",
                "Pre-T gooood",
                7);

            var nota10 = CreateNota(
                "Finished",
                "Task completed",
                9);

            var nota11 = CreateNota(
                "Great Task",
                "This task is awesome",
                10);
            
            var nota12 = CreateNota(
                "This is the best Task",
                "If only they could all be like this one",
                10);

            notas.Add(nota1);
            notas.Add(nota2);
            notas.Add(nota3);
            notas.Add(nota4);
            notas.Add(nota5);
            notas.Add(nota6);
            notas.Add(nota7);
            notas.Add(nota8);
            notas.Add(nota9);
            notas.Add(nota10);
            notas.Add(nota11);
            notas.Add(nota12);

            inMem.Notas.AddRange(notas);
        }

        private _Nota CreateNota(
            string title,
            string text,
            int opusId)
        {
            var id = 0;
            var nota = new _Nota
            {
                NotaId = id,
                OpusId = opusId,
                Title = title,
                Text = text
            };

            return nota;
        }
    }
}
