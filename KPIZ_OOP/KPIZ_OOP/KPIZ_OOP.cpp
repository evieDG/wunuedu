#include <iostream>
#include <string>
using namespace std;

// Структура, що представляє відомості про квартиру
struct Apartment {
    int rooms;
    int floor;
    double area;
    string address;
    Apartment* next;
};

// Клас, який містить функціональність для роботи з картотекою
class ApartmentCatalog {
private:
    Apartment* head; // Початковий елемент списку
public:
    // Конструктор
    ApartmentCatalog() {
        head = nullptr;
    }

    // Функція для додавання нової квартири до картотеки
    void addApartment(int rooms, int floor, double area, const string& address) {
        Apartment* newApartment = new Apartment;
        newApartment->rooms = rooms;
        newApartment->floor = floor;
        newApartment->area = area;
        newApartment->address = address;
        newApartment->next = nullptr;

        if (head == nullptr) {
            head = newApartment;
        }
        else {
            Apartment* current = head;
            while (current->next != nullptr) {
                current = current->next;
            }
            current->next = newApartment;
        }
    }

    // Функція для видалення квартири з картотеки
    void removeApartment(Apartment* apartment) {
        if (head == apartment) {
            head = apartment->next;
        }
        else {
            Apartment* current = head;
            while (current->next != apartment) {
                current = current->next;
            }
            current->next = apartment->next;
        }
        delete apartment;
    }

    // Функція для пошуку відповідного варіанту обміну
    void findMatchingApartment(int rooms, int floor, double area) {
        setlocale(LC_ALL, "UKR");
        Apartment* current = head;
        Apartment* previous = nullptr;
        

        while (current != nullptr) {
            if (current->rooms == rooms && current->floor == floor &&
                current->area >= (area - 5) && current->area <= (area + 5)) {
                cout << "Знайдено відповідний варіант:" << endl;
                cout << "Кількість кімнат: " << current->rooms << endl;
                cout << "Поверх: " << current->floor << endl;
                cout << "Площа: " << current->area << endl;
                cout << "Адреса: " << current->address << endl;

                if (previous == nullptr) {
                    head = current->next;
                }
                else {
                    previous->next = current->next;
                }
                delete current;
                return;
            }
            previous = current;
            current = current->next;
        }

        cout << "Відповідного варіанту не знайдено." << endl;
    }

    // Функція для виведення всього списку
    void displayCatalog() {
        setlocale(LC_ALL, "UKR");
        Apartment* current = head;
        cout << "Картотека обміну квартир:" << endl;
        while (current != nullptr) {
            cout << "Кількість кімнат: " << current->rooms << endl;
            cout << "Поверх: " << current->floor << endl;
            cout << "Площа: " << current->area << endl;
            cout << "Адреса: " << current->address << endl << endl;
            current = current->next;
        }
    }
};

int main() {
    setlocale(LC_ALL, "UKR");
    ApartmentCatalog catalog;

    while (true) {
        cout << "Меню:" << endl;
        cout << "1. Додати квартиру до картотеки" << endl;
        cout << "2. Відправити заявку на обмін" << endl;
        cout << "3. Вивести список квартир" << endl;
        cout << "0. Вийти з програми" << endl;
        cout << "Ваш вибір: ";

        int choice;
        cin >> choice;

        if (choice == 0) {
            break;
        }
        else if (choice == 1) {
            int rooms, floor;
            double area;
            string address;

            cout << "Введіть кількість кімнат: ";
            cin >> rooms;
            cout << "Введіть поверх: ";
            cin >> floor;
            cout << "Введіть площу: ";
            cin >> area;
            cout << "Введіть адресу: ";
            cin.ignore();
            getline(cin, address);

            catalog.addApartment(rooms, floor, area, address);
            cout << "Квартира додана до картотеки." << endl;
        }
        else if (choice == 2) {
            int rooms, floor;
            double area;

            cout << "Введіть кількість кімнат: ";
            cin >> rooms;
            cout << "Введіть поверх: ";
            cin >> floor;
            cout << "Введіть площу: ";
            cin >> area;

            catalog.findMatchingApartment(rooms, floor, area);
        }
        else if (choice == 3) {
            catalog.displayCatalog();
        }
        else {
            cout << "Невірний вибір. Спробуйте ще раз." << endl;
        }

        cout << endl;
    }

    return 0;
}
