import { Image } from "./Image"

export interface CreateProduct{
    title: string
    price:number
    description:string
    categoryId:number
    images:Image[]
}