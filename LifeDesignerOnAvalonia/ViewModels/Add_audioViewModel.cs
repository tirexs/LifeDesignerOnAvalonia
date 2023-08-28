using ReactiveUI;
using System.Reactive;
using NAudio.Wave;
using System.IO;
using System.Media;
using System;
using LifeDesignerOnAvalonia.Services;

namespace LifeDesignerOnAvalonia.ViewModels
{
    public class Add_audioViewModel : ViewModelBase
    {

        #region private
        private ItemsCollectionService _service;
        private WaveInEvent waveIn;
        private MemoryStream outputStream;
        private string errText;
        #endregion

        static string audioFile = "D:\\programming\\C#\\LifeDesignerOnAvalonia\\LifeDesignerOnAvalonia\\test.wav";
        readonly SoundPlayer soundPlayer = new SoundPlayer(audioFile);
        public ReactiveCommand<Unit, Unit> StartRecordingCommand { get; }
        public ReactiveCommand<Unit, Unit> StopRecordingCommand { get; }

        public string ErrText
        {
            get { return errText; }
            set { this.RaiseAndSetIfChanged(ref errText, value); }
        }

        public Add_audioViewModel(ItemsCollectionService service)
        {
            _service = service;
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

        private void StartRecording()
        {
            waveIn.StartRecording();
        }
        
        private void StopRecording()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            byte[] AudioBytes = outputStream.ToArray();
            outputStream.Dispose();
            string NameRecord = DateTime.Now.ToString("yyyy-MM-dd");

            if (AudioBytes == null)
            {
                ErrText = "попробуйте ещё раз";
            }
            else
            {
                _service.AddAudio(NameRecord, AudioBytes);
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
