package com.example.lifecycle_example;

import android.os.Bundle;
import android.util.Log;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    private final String hashTag = "Main activity";
    private final String counterHashTag = "Counter info";
    private Integer counter;
    private final String counterKey = "counterKey";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        Log.d(hashTag, "onCreate method");
        if (savedInstanceState == null) {
            counter = 0;
            Log.w(counterHashTag, String.format("Counter init %s\n", counter));
        } else {
            counter = savedInstanceState.getInt(counterKey) + 1;
            Log.w(counterHashTag, String.format("Counter is from saved state %s\n", counter));
        }
    }

    @Override
    protected void onStart() {
        super.onStart();
        Log.d(hashTag, "onStart method");
    }

    @Override
    protected void onRestart() {
        super.onRestart();
        Log.d(hashTag, "onRestart method");
    }

    @Override
    protected void onResume() {
        super.onResume();
        Log.d(hashTag, "onResume method");
    }

    @Override
    protected void onPause() {
        super.onPause();
        Log.d(hashTag, "onPause method");
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.d(hashTag, "onStop method");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.d(hashTag, "onDestroy method");
    }

    @Override
    protected void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putInt(counterKey, counter);
        Log.w(counterHashTag, String.format("Counter is %s\n", counter));
    }

    public void exitApp(View view) {
        Log.w(counterHashTag, String.format("Counter is %s in finish\n", counter));
        finish();
    }
}