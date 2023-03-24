import { Category } from "./category"
import { Image } from "./Image"

export interface Product {
    id: number
    title: string
    description:string
    price:number
    category: Category
    images:Image[]
    quantity?:number
    subTotal?:number
}


export interface ModifyProduct{
    updateId:number|undefined
    update:{
        title?:string
        description?:string
        price?:number
        category?: string
    }
    
}

export interface Iprops {
    title?:string
    price?: number
    description?: string
    category?: string
    images?: string[]
    create?: string
    update?: string
    cancel?: string 
}