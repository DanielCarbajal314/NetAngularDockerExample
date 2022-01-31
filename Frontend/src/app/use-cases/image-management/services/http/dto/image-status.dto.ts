import { RegisteredImage } from "./registered-image.dto";

export interface ImageStatus extends RegisteredImage {
    wasProcessed: boolean;
}