import { createProduct, createProductWithForm, CreateProductWithForm, deleteAproduct,fetchAllProducts, modifyProduct, sortByName, sortByPrice } from "../../redux/reducers/productReducer"
import { createStore } from "../../redux/store"
import { CreateProduct } from "../../types/createProduct"
import { StoreInterface } from "../../types/StoreInterface"
import server from "../shared/server"
import { testProductData } from "../test-data/productTestData"

let store: StoreInterface

beforeAll(() => {
    server.listen()
})

afterAll(() => {
    server.close()
})

beforeEach(() => {
    store = createStore()
})

describe("Testing actions from product reducer", () => {
    test("Should get the initial state", () => {
        expect(store.getState().productReducer.length).toBe(0)
    })
    test("Should fetch all the products", async () => {
        await store.dispatch(fetchAllProducts())
        expect(store.getState().productReducer.length).toBe(3)
    })
    test("Should create a product", async()=>{
        const newProduct:CreateProduct = {
            title:'A',
            price:500,
            description:'creating a new product',
            categoryId:2,
            images:[]
        }
        await store.dispatch(createProduct(newProduct))
        expect(store.getState().productReducer.length).toBe(1)
    })
    test("Should not create a product", async()=>{
        const newProduct:CreateProduct = {
            title:'A',
            price:0,
            description:'creating a new product',
            categoryId:2,
            images:[]
        }
        await store.dispatch(createProduct(newProduct))
        expect(store.getState().productReducer.length).toBe(0)
    })
    test("Should create a product with form data",async () => {
        const image:File = {
            lastModified: 0,
            name: "test file image",
            webkitRelativePath: "",
            size: 0,
            type: "",
            arrayBuffer: function (): Promise<ArrayBuffer> {
                throw new Error("Function not implemented.")
            },
            slice: function (start?: number | undefined, end?: number | undefined, contentType?: string | undefined): Blob {
                throw new Error("Function not implemented.")
            },
            stream: function () {
                throw new Error("Function not implemented.")
            },
            text: function (): Promise<string> {
                throw new Error("Function not implemented.")
            }
        }
        const product:CreateProduct = {
            title:'A',
            price:500,
            description:'creating a new product',
            categoryId:2,
            images:[]
        }
        await store.dispatch(createProductWithForm({image, product}))
        expect(store.getState().productReducer.length).toBe(1)
    })

    test("Should update available product",async () => {
        await store.dispatch(fetchAllProducts())
        await store.dispatch(modifyProduct({
            updateId:11,
            update:{
                price: 600,
                title:'Testing the modify function'
            }
        }))
       
        expect(store.getState().productReducer.find(product => product.id === 11)?.price).toEqual(600)
        expect(store.getState().productReducer.find(product => product.id === 11)?.title).toBe('Testing the modify function')
    })
    test("Should sort the products in ascending/descending order", async () => {
        await store.dispatch(fetchAllProducts())
        store.dispatch(sortByName('asc')) // with 'desc' sort in descending order
        expect(store.getState().productReducer[0].title).toBe('Electronic Rubber Sauce')
        expect(store.getState().productReducer[1].title).toBe('Incredible Metal Bacon')
        expect(store.getState().productReducer[2].title).toBe('Tasty Granite Mouse')
    })
    test("Should sort the products price in ascending/descending order", async () => {
        await store.dispatch(fetchAllProducts())
        store.dispatch(sortByPrice('asc'))
        expect(store.getState().productReducer[0].price).toBe(120)
        expect(store.getState().productReducer[1].price).toBe(317)
        expect(store.getState().productReducer[2].price).toBe(553)
    })
    test("Should delete a product from server", async()=>{
        await store.dispatch(fetchAllProducts())
        await store.dispatch(deleteAproduct(testProductData[1].id))
        expect(store.getState().productReducer[1].id).toBe(11)
    })
})



