using LifeDesignerOnAvalonia.Models;
using ReactiveUI;
using System.Reactive;
using NAudio.Wave;
using System.IO;
using System.Media;
using System.Linq;
using System;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_audioViewModel : ViewModelBase
    {
        private WaveInEvent waveIn;
        private MemoryStream outputStream;
        static string audioFile = "D:\\programming\\C#\\LifeDesignerOnAvalonia\\LifeDesignerOnAvalonia\\test.wav";
        readonly SoundPlayer soundPlayer = new SoundPlayer(audioFile);

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

        public Add_audioViewModel()
        {
            StartRecordingCommand = ReactiveCommand.Create(StartRecording);
            StopRecordingCommand = ReactiveCommand.Create(StopRecording);
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(8000, 16, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;
            outputStream = new MemoryStream();
            
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            outputStream.Write(e.Buffer, 0, e.BytesRecorded);
        }


        public ReactiveCommand<Unit, Unit> StartRecordingCommand { get; }

        private void StartRecording()
        {
            waveIn.StartRecording();
        }
        
        
        
        
        
        public ReactiveCommand<Unit, Unit> StopRecordingCommand { get; }
        
        private void StopRecording()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            byte[] audioBytes = outputStream.ToArray();
            outputStream.Dispose();
            var NameRecord = DateTime.Now.ToString("yyyy-MM-dd");

            if (audioBytes == null)
            {
                ErrText = "попробуйте ещё раз";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var id = context.Categorys.Where(n => n.Name == ItemsCollection.SelectedItem.Header).Select(n => n.Id).FirstOrDefault();
                    var audioData = new AudioData()
                    {
                        Name = NameRecord,
                        IdCategory = id,
                        IdUser = ItemsCollection.IdUser,
                        Audio = audioBytes
                    };

                    context.audioData.Add(audioData);
                    context.SaveChanges();

                    var item = ItemsCollection.Items.FirstOrDefault(i => i.Header == ItemsCollection.SelectedItem.Header);
                    if (item != null)
                    {
                        item.AudioName.Add(NameRecord);
                    }
                }
            }
        }

        //private void SaveAsWaveFile(string filePath, byte[] audioBytes)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        using (var writer = new WaveFileWriter(memoryStream, waveIn.WaveFormat))
        //        {
        //            writer.Write(audioBytes, 0, audioBytes.Length);
        //        }

        //        File.WriteAllBytes(filePath, memoryStream.ToArray());
        //    }
        //}



    }
}
