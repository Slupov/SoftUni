// //ALTERNATIVE SOLUTION (NOT FINISHED)
// function lowestPrices(sales) {
//     let townsProducts = new Map();
//     let result = [];
//
//     //walk through every sale and add the info to the towns
//     for (let sale of sales) {
//         let [town,productName,productPrice] = sale.split(" | ");
//         productPrice = Number(productPrice);
//
//         if (!townsProducts.has(town)){
//             townsProducts.set(town, new Map());
//         }
//         // update product's price
//         townsProducts.get(town).set(productName, productPrice);
//     }
//
//    findBestProduct(townsProducts);
//
//
//
// }
//
// function findBestProduct(townsMap) {
//     let bestProduct = new Map();
//     //check every town
//     for (let town of townsMap.keys()) {
//         //check every product of the town
//         for (let product of townsMap[town]) {
//           //check that product in all other towns
//             for (let town of townsMap.keys()) {
//                 if(town.){
//
//                 }
//             }
//         }
//     }
// }
//
// let test = [
//     'Sample Town | Sample Product | 1000',
//     'Sample Town | Orange | 2',
//     'Sample Town | Peach | 1',
//     'Sofia | Orange | 3',
//     'Sofia | Peach | 2',
//     'New York | Sample Product | 1000.1',
//     'New York | Burger | 10'
// ];
// lowestPrices(test);