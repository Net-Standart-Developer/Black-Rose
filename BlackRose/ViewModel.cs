using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Threading;
namespace BlackRose
{
    class ViewModel : INotifyPropertyChanged
    {
        System.Windows.Application application;
        public FullTrack StartingRecord { get; set; }
        public ObservableCollection<FullTrack> Records { get; set; }
        private IFileService fileService;
        private MainWindow window;
        public bool IsNeededStartRec = true;
        public bool IsPause = false;
        public bool IsOpen = false;
        
        private int number = -1;

        public int DurationCurrentTrack
        {
            get
            {
                if (IsOpen && StartingRecord.Player.NaturalDuration.HasTimeSpan)
                {
                    return (int)StartingRecord.Player.NaturalDuration.TimeSpan.TotalSeconds;
                }
                else return 0;
            }
        }
        public int Position
        {
            get
            {
                if(IsOpen /*&& StartingRecord !=null*/)
                {
                    return (int)StartingRecord.Player.Position.TotalSeconds;
                }
                return 0;
            }
            set
            {
                if(StartingRecord != null)  //временное решение, убрав слайдер при отсутствии трека обдумать этот set
                {
                    StartingRecord.Player.Position = TimeSpan.FromSeconds(value);
                    OnPropertyChanged("Position");
                }
                
            }
        }

        private FullTrack selectedRecord;
        public FullTrack SelectedRecord
        {
            get
            {
                return selectedRecord;
            }
            set
            {
                selectedRecord = value;
                OnPropertyChanged();
            }
        }

        private float volume = 0.5F;
        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                for(int count = 0; count < Records.Count; count++)
                {
                    Records[count].Player.Volume = value;
                }
                OnPropertyChanged();
            }
        }

        //private RelayCommand delay;
        //public RelayCommand Delay
        //{
        //    get
        //    {
        //        return delay ?? (delay = new RelayCommand(obj =>
        //        {
        //            PauseTrack.Execute(null);               
        //        }));
        //    }
        //}

        //private RelayCommand mouseLeave;
        //public RelayCommand MouseLeave
        //{
        //    get
        //    {
        //        return mouseLeave ??
        //            (mouseLeave = new RelayCommand(obj =>
        //            {
        //                StartTrack.Execute(null);
        //            }));
        //    }
        //}

        private RelayCommand addTrack;
        public RelayCommand AddTrack
        {
            get
            {
                return addTrack ??
                    (addTrack = new RelayCommand(obj =>
                    {
                        string name = fileService.Path;
                        if (name != null)
                        {
                            MediaPlayer mediaPlayer = new MediaPlayer();
                            mediaPlayer.MediaOpened += (sender, eventargs) =>
                            {
                                IsOpen = true;
                            };
                            mediaPlayer.MediaEnded += (sender, eventargs) =>
                            {
                                IsOpen = false;
                                if (number == Records.Count - 1)
                                    number = 0;
                                else
                                    number++;

                                StartTrack.Execute(Records.ElementAt(number));
                                SelectedRecord = Records.ElementAt(number);

                            };
                            mediaPlayer.MediaFailed += (sender, eventargs) =>
                            {
                                IsOpen = false;
                            };
                            Records.Add(new FullTrack(new Track(name), mediaPlayer));
                        }
                    }));
            }
        }
        public void TakeNewTrack(string path)  //3 обработчика для mediaPlayer заданы 3 раза
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaOpened += (sender, eventargs) =>
            {
                IsOpen = true;
            };
            mediaPlayer.MediaEnded += (sender, eventargs) =>
            {
                IsOpen = false;
                if (number == Records.Count - 1)
                    number = 0;
                else
                    number++;

                StartTrack.Execute(Records.ElementAt(number));
                SelectedRecord = Records.ElementAt(number);
            };
            mediaPlayer.MediaFailed += (sender, eventargs) =>
            {
                IsOpen = false;
            };
            Records.Add(new FullTrack(new Track(path), mediaPlayer));
        }
        private RelayCommand delete;
        public RelayCommand Delete
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(obj =>
                    {
                        if(SelectedRecord == StartingRecord)
                        {
                            StopTrack.Execute(SelectedRecord);
                        }
                        Records.Remove(SelectedRecord);
                    },
                    obj =>
                    {
                        return SelectedRecord != null;
                    }));
            }
        }
        private RelayCommand forward;
        public RelayCommand Forward
        {
            get
            {
                return forward ??
                    (forward = new RelayCommand(obj =>
                    {
                        if (number == Records.Count - 1)
                            number = 0;
                        else number++;
                        StartTrack.Execute(Records.ElementAt(number++));
                        SelectedRecord = Records.ElementAt(number);
                        IsPause = false;
                    },
                    obj =>
                    {
                        return IsOpen;
                    }));
            }
        }
        private RelayCommand back;
        public RelayCommand Back
        {
            get
            {
                return back ??
                    (back = new RelayCommand(obj =>
                    {
                        if (number == 0)
                            number = Records.Count - 1;
                        else number--;
                            StartTrack.Execute(Records.ElementAt(number));
                        SelectedRecord = Records.ElementAt(number);
                        IsPause = false;
                    },
                    obj =>
                    {
                        return IsOpen;
                    }));
            }
        }

        private RelayCommand addDirectory;
        public RelayCommand AddDirectory
        {
            get
            {
                return addDirectory ??
                    (addDirectory = new RelayCommand(obj =>
                    {
                        List<FullTrack> list = fileService.DirOfTracks;
                        if(list != null)
                        {
                            foreach(var t in list)
                            {
                                t.Player.MediaOpened += (sender, eventargs) =>
                                {
                                    IsOpen = true;
                                };
                                t.Player.MediaEnded += (sender, eventargs) =>
                                {
                                    IsOpen = false;
                                    if (number == Records.Count - 1)
                                        number = 0;
                                    else
                                        number++;

                                    StartTrack.Execute(Records.ElementAt(number));
                                    SelectedRecord = Records.ElementAt(number);
                                    SelectedRecord.Player.Volume = volume;
                                };
                                t.Player.MediaFailed += (sender, eventargs) =>
                                {
                                    IsOpen = false;
                                };
                                Records.Add(t);
                            }
                        }
                    }));
            }
        }

        private RelayCommand startTrack;
        public RelayCommand StartTrack
        {
            get
            {
                return startTrack ??
                    (startTrack = new RelayCommand(obj =>
                    {
                        FullTrack record = obj as FullTrack;
                        if(record != null)
                        {
                            if(StartingRecord != null)
                                StartingRecord.Player.Close();

                            number = Records.IndexOf(record);

                            record.Player.Open(new Uri(record.Track.Name));
                            record.Player.Play();
                            StartingRecord = record;
                            IsOpen = true;
                        }
                    }));
            }
        }

        private RelayCommand stopTrack;
        public RelayCommand StopTrack
        {
            get
            {
                return stopTrack ??
                    (stopTrack = new RelayCommand(obj =>
                    {
                        StartingRecord.Player.Stop();
                        StartingRecord.Player.Close();
                        IsOpen = false;
                        StartingRecord = null;
                    }, obj =>
                    {
                        return StartingRecord != null;
                    }));
            }
        }

        private RelayCommand pauseTrack;
        public RelayCommand PauseTrack
        {
            get
            {
                return pauseTrack ??
                    (pauseTrack = new RelayCommand(obj =>
                    {
                        StartingRecord.Player.Pause();
                        IsPause = true;
                    }, obj =>
                    {
                        return StartingRecord != null && !IsPause;
                    }));
            }
        }

        private RelayCommand continueTrack;
        public RelayCommand ContinueTrack
        {
            get
            {
                return continueTrack ??
                    (continueTrack = new RelayCommand(obj =>
                    {
                        StartingRecord.Player.Play();
                        IsPause = false;
                        IsNeededStartRec = true;
                    },
                    obj =>
                    {
                        return StartingRecord != null && IsPause;
                    }));
            }
        }

        private RelayCommand exit;
        public RelayCommand Exit
        {
            get
            {
                return exit ??
                    (exit = new RelayCommand(obj =>
                    {
                        this.application.Shutdown();
                    }));
            }
        }


        public ViewModel(IFileService fileService, System.Windows.Application application, MainWindow window)
        {
            this.window = window;
            Records = new ObservableCollection<FullTrack>();
            this.application = application;
            this.fileService = fileService;
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    OnPropertyChanged("Position");
                    OnPropertyChanged("DurationCurrentTrack");
                }

            });
            thread.IsBackground = true;
            thread.Start();


        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
