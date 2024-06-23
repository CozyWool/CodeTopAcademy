#include <iostream>
#include <map>
#include <vector>

int main() {
    // std::vector<int> numbers{10, , 20 30, 40};
    // //   // std::vector<int>::iterator iter = numbers.begin();
    // auto iter{numbers.begin()};
    // //*iter
    // // ++iter --iter
    // // iter1 == iter2
    // // iter +- n
    // // iter +-= n
    // // iter1 - iter2
    //   std::cout << *iter << std::endl;
    //   *iter = 12;
    //   std::cout << numbers[0] << std::endl;
    // ++iter;
    // std::cout << *iter;
    // iter += 2;
    // std::cout << *iter;
    // iter = iter - 3;
    // std::cout << *iter;

    // auto iter{numbers.begin()};
    // if (iter != numbers.end()) {
    //   if (*iter == value) {
    //   }
    // }

    // for (auto iter)

    //   void sort_descending() {
    //       std::sort(container.begin(), container.end(),
    //       std::greater<uint64_t>());
    //   }

    // std::vector<int> numbers{10, 20, 30, 40};
    // auto iter{numbers.begin()};

    // while (iter != numbers.end()) {
    //   std::cout << *iter << std::endl;
    //   ++iter;
    // }

    // for (auto start(numbers.begin()); start != numbers.end(); start++) {
    //   std::cout << *iter << std::endl;
    // }

    std::map<std::string, unsigned> products{
      std::pair<std::string, unsigned>{"bread", 50},std::pair<std::string, unsigned>{"milk", 80}
    };

    products.erase("milk");
    products.size();
    products.empty();
    products.count("milk");
    products.contains("milk");
    auto iter = products.find("milk");
    // products["bread"] = 50;
    // products["milk"] = 80;
    // products["kefir"] = 60;
    // products["bread"] = 70;
    // products.insert("breads", 70);
    // products.insert("bread", 90);
    // for (const auto &[product, price] : products) {
    //   std::cout << product << price;
    // }

    // products.insert(std::make_pair("bread", 70));

    // for (const auto& element: products){
    //   std::cout << element.first << element.second;
    // }
}