import { SheetColor } from '../dictionaries/sheet-color.enum';
import { ProductionStatus } from '../dictionaries/production-status';

export interface GetOrderInfo {
        idOrder;
        idOffer;
        imagePath;
        itemName;
        userName;
        surname;
        street;
        city;
        location;
        zipNumber;
        houseNumber;
        email;
        telephoneNumber;
        xLength;
        yLength;
        zLength;
        doorType;
        doorXLength;
        doorYLength;
        colorName;
        sheetType;
        price;
        dateOfOrder;
        dateOfFinishOrder;
        productionStatus;
        paymentStatus;
        kindOfPayment;
//   // item details
//   idOrder;
//   offer: {
//     idOffer;
//     imagePath;
//     name;
//     available;
//     shortDescription;
//     longDescription;
//     badgeColour;
//     badgeContent;
//     price;
//     discount;
//     availableSizes: any[];
//     availableDoors: any[];
//     availableSheets: any[];
//   };
//   imagePath;
//   user: {
//       id;
//       name;
//       surname,
//       password;
//       role;
//       street;
//       city;
//       location;
//       zipNumber;
//       houseNumber;
//       email;
//       telephoneNumber;
//   };
//   itemDetails: {
//       idItemDetails;
//       xLength;
//       yLength;
//       zLength;
//       doorType;
//       doorXLength;
//       doorYLength;
//       colorName;
//       sheetType;
//   };
//   address: {
//     idAddress;
//     street;
//     city;
//     houseNumber;
//     location;
//     zipCode;
// };

// contact: {
//     idContact;
//     email;
//     telephoneNumber;
// };

//   price;
//   dateOfOrder;
//   dateOfFinishOrder;
//   productionStatus;
//   payment: {
//       paymentStatus;
//       kindOfPayment;
//   };
}

