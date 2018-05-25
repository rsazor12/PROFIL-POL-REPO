import { OfferDetails } from './garage-card-content';
export interface OfferDetails {
   idOffer: string;
   imagePath: string;
   name: string;
   available: boolean;
   shortDescription: string;
   longDescription: string;
   badgeColour: string;
   badgeContent: string;
   price: number;
   discount: number;
   availableSizes: any[];
   availableDoors: any[];
   availableSheets: any[];

}
