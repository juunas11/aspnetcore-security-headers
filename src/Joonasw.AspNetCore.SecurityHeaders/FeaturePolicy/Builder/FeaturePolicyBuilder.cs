namespace Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder
{
    public class FeaturePolicyBuilder
    {
        private readonly  FeaturePolicyOptions _options = new FeaturePolicyOptions();

        /// <summary>
        /// Set up rules for Geolocation.
        /// </summary>
        public FeaturePolicyGeolocationBuilder AllowGeolocation { get; } = new FeaturePolicyGeolocationBuilder();
        /// <summary>
        /// Set up rules for Midi
        /// </summary>
        public FeaturePolicyMidiBuilder AllowMidi { get; } = new FeaturePolicyMidiBuilder();
        /// <summary>
        /// Set up rules for Notifications
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyNotificationsBuilder AllowNotifications { get; } = new FeaturePolicyNotificationsBuilder();
        /// <summary>
        /// Set up rules for Push
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyPushBuilder AllowPush { get; } = new FeaturePolicyPushBuilder();
        /// <summary>
        /// Set up rules for Sync Xhr
        /// </summary>
        public FeaturePolicySyncXhrBuilder AllowSyncXhr { get; } = new FeaturePolicySyncXhrBuilder();
        /// <summary>
        /// Set up rules for Microphone use
        /// </summary>
        public FeaturePolicyMicrophoneBuilder AllowMicrophone { get; } = new FeaturePolicyMicrophoneBuilder();
        /// <summary>
        /// Set up rules for Camera use
        /// </summary>
        public FeaturePolicyCameraBuilder AllowCamera { get; } = new FeaturePolicyCameraBuilder();
        /// <summary>
        /// Set up rules for Magnetometer
        /// </summary>
        public FeaturePolicyMagnetometerBuilder AllowMagnetometer { get; } = new FeaturePolicyMagnetometerBuilder();
        /// <summary>
        /// Set up rules for Gyroscope
        /// </summary>
        public FeaturePolicyGyroscopeBuilder AllowGyroscope { get; } = new FeaturePolicyGyroscopeBuilder();
        /// <summary>
        /// Set up rules for Speaker use
        /// </summary>
        public FeaturePolicySpeakerBuilder AllowSpeaker { get; } = new FeaturePolicySpeakerBuilder();
        /// <summary>
        /// Set up rules for Vibrate
        /// No Chrome support as of 2017-07-30
        /// </summary>
        public FeaturePolicyVibrateBuilder AllowVibrate { get; } = new FeaturePolicyVibrateBuilder();
        /// <summary>
        /// Set up rules for Fullscreen use
        /// </summary>
        public FeaturePolicyFullscreenBuilder AllowFullscreen { get; } = new FeaturePolicyFullscreenBuilder();
        /// <summary>
        /// Set up rules for Payment use
        /// </summary>
        public FeaturePolicyPaymentBuilder AllowPayment { get; } = new FeaturePolicyPaymentBuilder();
        /// <summary>
        /// Set up rules for Accelerometer use
        /// </summary>
        public FeaturePolicyAccelerometerBuilder AllowAccelerometer { get; } = new FeaturePolicyAccelerometerBuilder();
        /// <summary>
        /// Set up rules for Ambient Light Sensor use
        /// </summary>
        public FeaturePolicyAmbientLightSensorBuilder AllowAmbientLightSensor { get; } = new FeaturePolicyAmbientLightSensorBuilder();
        /// <summary>
        /// Set up rules for Autoplay use
        /// </summary>
        public FeaturePolicyAutoplayBuilder AllowAutoplay { get; } = new FeaturePolicyAutoplayBuilder();
        /// <summary>
        /// Set up rules for Encrypted Media use
        /// </summary>
        public FeaturePolicyEncryptedMediaBuilder AllowEncryptedMedia { get; } = new FeaturePolicyEncryptedMediaBuilder();
        /// <summary>
        /// Set up rules for Picture in Picture use
        /// </summary>
        public FeaturePolicyPictureInPictureBuilder AllowPictureInPicture { get; } = new FeaturePolicyPictureInPictureBuilder();
        /// <summary>
        /// Set up rules for USB use
        /// </summary>
        public FeaturePolicyUsbBuilder AllowUsb { get; } = new FeaturePolicyUsbBuilder();
        /// <summary>
        /// Set up rules for VR use
        /// </summary>
        public FeaturePolicyVrBuilder AllowVr { get; } = new FeaturePolicyVrBuilder();

        internal FeaturePolicyOptions BuildFeaturePolicyOptions()
        {
            _options.GeolocationOptions = AllowGeolocation.BuildOptions();
            _options.MidiOptions = AllowMidi.BuildOptions();
            _options.NotificationsOptions = AllowNotifications.BuildOptions();
            _options.PushOptions = AllowPush.BuildOptions();
            _options.SyncXhrOptions = AllowSyncXhr.BuildOptions();
            _options.MicrophoneOptions = AllowMicrophone.BuildOptions();
            _options.CameraOptions = AllowCamera.BuildOptions();
            _options.MagnetometerOptions = AllowMagnetometer.BuildOptions();
            _options.GyroscopeOptions = AllowGyroscope.BuildOptions();
            _options.SpeakerOptions = AllowSpeaker.BuildOptions();
            _options.VibrateOptions = AllowVibrate.BuildOptions();
            _options.FullscreenOptions = AllowFullscreen.BuildOptions();
            _options.PaymentOptions = AllowPayment.BuildOptions();
            _options.AccelerometerOptions = AllowAccelerometer.BuildOptions();
            _options.AmbientLightSensorOptions = AllowAmbientLightSensor.BuildOptions();
            _options.AutoplayOptions = AllowAutoplay.BuildOptions();
            _options.EncryptedMediaOptions = AllowEncryptedMedia.BuildOptions();
            _options.PictureInPictureOptions = AllowPictureInPicture.BuildOptions();
            _options.UsbOptions = AllowUsb.BuildOptions();
            _options.VrOptions = AllowVr.BuildOptions();

            return _options;
        }
    }
}
