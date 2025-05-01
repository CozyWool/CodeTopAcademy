package com.example.example_db;

import static android.content.Context.MODE_PRIVATE;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class DatabaseManager extends SQLiteOpenHelper {
    private final String table_name = "contacts";

    private Context _context;
    private final String databaseName;

    public DatabaseManager(@Nullable Context context, @Nullable String _databaseName, @Nullable SQLiteDatabase.CursorFactory factory, int version) {
        super(context, _databaseName, factory, version);
        _context = context;
        this.databaseName = _databaseName;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
//        db.execSQL("CREATE DATABASE IF NOT EXISTS %s", table_name);
        db.execSQL(String.format("CREATE TABLE IF NOT EXISTS %s" +
                "(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, phone TEXT)", table_name));
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + table_name);
        onCreate(db);
    }

    public void add(String name, String phone) {
        var db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("name", name);
        values.put("phone", phone);
        db.insert(table_name, null, values);
        db.close();
    }

    public void delete(Integer id) {
        var db = this.getWritableDatabase();
        db.delete(table_name, "id = ?", new String[]{id.toString()});
        db.close();
    }

    public List<PhoneItem> select() {
        var db = this.getWritableDatabase();
        List<PhoneItem> phoneItems = new ArrayList<>();
        try (var cursor = db.query(table_name,
                new String[]{"id", "name", "phone"},
                null,
                null,
                null,
                null,
                null)) {
            while (cursor.moveToNext()) {
                var item = new PhoneItem();
                item.setId(cursor.getInt(0));
                item.setName(cursor.getString(1));
                item.setPhone(cursor.getString(2));
                phoneItems.add(item);
            }
        }
        db.close();
        return phoneItems;
    }


        public void update(PhoneItem item) {
        var db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put("id", item.getId());
        values.put("name", item.getName());
        values.put("phone", item.getPhone());
        db.update(table_name, values, "id = ?", new String[]{item.getId().toString()});
    }
}
