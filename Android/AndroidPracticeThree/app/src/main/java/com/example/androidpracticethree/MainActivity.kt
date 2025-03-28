package com.example.androidpracticethree

import android.app.AlertDialog
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    private lateinit var nameEditText: EditText
    private lateinit var descriptionEditText: EditText
    private lateinit var toDateEditText: EditText
    private var taskList: ArrayList<Task> = ArrayList();

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        nameEditText = findViewById(R.id.nameEditText)
        descriptionEditText = findViewById(R.id.descriptionEditText)
        toDateEditText = findViewById(R.id.toDateEditText)
    }

    fun onSubmitButtonClick(view: View) {
        if (toDateEditText.text.isEmpty() || descriptionEditText.text.isEmpty() || nameEditText.text.isEmpty()) {
            Toast.makeText(this, "Заполните все поля!", Toast.LENGTH_LONG).show()
            return;
        }
        val name = nameEditText.text.toString();
        val description = descriptionEditText.text.toString();
        val toDate = toDateEditText.text.toString();

        val newTask = Task(name, description, toDate);
        taskList.add(newTask);

        Toast.makeText(this, "Успешно добавлено!", Toast.LENGTH_LONG).show()
        nameEditText.text = null;
        descriptionEditText.text = null;
        toDateEditText.text = null;
    }

    fun onShowButtonClick(view: View) {
        val sb = StringBuilder()
        for (task in taskList) {
            sb.appendLine("${task.name} - ${task.description}; Выполнить до: ${task.toDate}")
        }

        val text = sb.toString();
        val builder = AlertDialog.Builder(this);
        builder.setTitle("Список дел").setMessage(text)
        val dialog = builder.create();
        dialog.show();
    }
}