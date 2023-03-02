package com.example.schedule;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentPagerAdapter;

public class SchedulePagerAdapter extends FragmentPagerAdapter {

    public SchedulePagerAdapter(FragmentManager fm) {
        super(fm);
    }

    @Override
    public Fragment getItem(int position) {
        // Возвращает соответствующий фрагмент в зависимости от позиции вкладки
        switch (position) {
            case 0:
                return new MondayFragment();
            case 1:
                return new TuesdayFragment();
            case 2:
                return new WednesdayFragment();
            case 3:
                return new ThursdayFragment();
            case 4:
                return new FridayFragment();
            case 5:
                return new SaturdayFragment();
            case 6:
                return new SundayFragment();
            default:
                return null;
        }
    }

    @Override
    public int getCount() {
        // Возвращает общее количество вкладок
        return 7;
    }

    @Override
    public CharSequence getPageTitle(int position) {
        // Возвращает заголовок вкладки
        switch (position) {
            case 0:
                return "ПН";
            case 1:
                return "ВТ";
            case 2:
                return "СР";
            case 3:
                return "ЧТ";
            case 4:
                return "ПТ";
            case 5:
                return "СБ";
            case 6:
                return "ВС";
            default:
                return null;
        }
    }
}