import { rest } from "msw"
import { setupServer } from "msw/node"
import { CreateProduct } from "../../types/createProduct"
import { Product } from "../../types/product"
import { testProductData } from "../test-data/productTestData"
import { users } from "../test-data/usersTestData"

const handler = [
    rest.get("https://orderlyonclick.azurewebsites.net/api/v1/products", (req, res, ctx) => {
        return res(
            ctx.json(testProductData)
        )
    }),
    rest.post("https://orderlyonclick.azurewebsites.net/api/v1/products", async (req, res, ctx) => {
        const product: CreateProduct = await req.json()
        if (product.price < 1) {
            return res(
                ctx.status(400, 'Use appropriate price')
            )
        }
        return res(
            ctx.json(product)
        )
    }),
    rest.post("https://api.escuelajs.co/api/v1/files/upload",async (req, res, ctx) => {
        const file:File = await req.json()
        res(
            ctx.json(
                {
                    orginalname: file.name,
                    filename: file.name,
                    location: `https://api.escuelajs.co/api/v1/files/${file.name}`
                }
            )
        )
    }),

    rest.put("https://orderlyonclick.azurewebsites.net/api/v1/products/:id", async (req, res, ctx) => {
        const update: Partial<Product> = await req.json()
        const { id } = req.params as any
        const foundProduct = testProductData.find((product => product.id === parseInt(id)))
        if (foundProduct) {
            return res(
                ctx.json({ ...foundProduct, ...update })
            )
        } else {
            return res(
                ctx.status(404, 'Product is not found')
            )
        }
    }),
    rest.delete(`https://orderlyonclick.azurewebsites.net/api/v1/products/:id`, async (req, res, ctx) => {
        // const productToDelete: Product = await req.json()
        // const { id } = req.params as any;
        const id = await req.json()
        const foundProductIndex = testProductData.findIndex(product => product.id !== parseInt(id))
        if (foundProductIndex>-1) {
            testProductData.splice(foundProductIndex,1)
            return res(ctx.json({success: true}));
        } else {
            return res(
                ctx.status(401, 'Bad request')
            )
        }
    }),
    rest.get("https://orderlyonclick.azurewebsites.net/api/v1/users", (req, res, ctx) => {
        return res(
            ctx.json(users)
        )
    }),
    rest.post("https://orderlyonclick.azurewebsites.net/api/v1/users/", async (req, res, ctx) => {
        const user = await req.json()
        ctx.json(user)
    })
]

const server = setupServer(...handler)
export default server



