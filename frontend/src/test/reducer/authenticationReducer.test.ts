import { createStore } from "../../redux/store";
import { StoreInterface } from "../../types/StoreInterface";
import server from "../shared/server";

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

describe("Testing the actions from authenticationReducer", () => {
    test("Should get the initial state", () => {
        expect(store.getState().authenticationReducer.user?.email).toBe("")
    })
    // test("Should get all the users", async() => {
    //     await store.dispatch(getAllUsers())
    //     expect(store.getState().userReducer.length).toBe(3)
    // })
    // test("Should create a new user/signUp", async () => {
    //     await store.dispatch(getAllUsers())
    //     await store.dispatch(createUser({
    //         "email": "johnny@mail.com",
    //         "password": "easy",
    //         "name": "Johnny",
    //         "role": "customer",
    //         "avatar": "https://api.lorem.space/image/face?w=640&h=480&r=6440"
    //     }))
    //     expect(store.getState().userReducer.length).toBe(4)

    // })
})