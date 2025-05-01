package com.example.menu_example;

import android.content.Context;
import android.graphics.Color;
import android.preference.PreferenceCategory;
import android.util.AttributeSet;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class CustomPreferenceCategory extends PreferenceCategory {
    public CustomPreferenceCategory(Context context, AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    protected View onCreateView(ViewGroup parent) {

        TextView categoryTitle = (TextView) super.onCreateView(parent);
        categoryTitle.setBackgroundColor(Color.WHITE);
        categoryTitle.setTextColor(Color.RED);

        return categoryTitle;
    }
}
