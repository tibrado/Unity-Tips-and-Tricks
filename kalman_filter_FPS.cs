    // -- Game FPS
    float deltaTime = 0.0f;
    float[] kalman = { 60, 1 }; // [Initial Estaimated, Initial Error]
    
    void FPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        float fps = 1.0f / deltaTime;
        kalman = KalmanFilter(fps, kalman[0], kalman[1]);
        fpsText.text = $"FPS: {Mathf.Round(kalman[0])}";
    }

    float[] KalmanFilter(float measurement, float pre_estimate, float error_estimate, float measurement_error = 1) // Returns an array of size 2 [Estaimated FPS, Error In Estimated FPS]
    {
        // 1. Kalman Gain 
        float gain = error_estimate / (error_estimate + measurement_error);
        
        // 2. Estimated Value 
        float estimate = pre_estimate + (gain * (measurement - pre_estimate));

        // 3. Error in Estimated Value
        float error = (1 - gain) * error_estimate;

        // Array for values
        float[] kalman = { estimate, error};
        return kalman;
    }
