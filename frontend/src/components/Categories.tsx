import { Box, TextField, InputAdornment, Button, Grid} from '@mui/material'
import React, { useEffect, useState } from 'react'
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook'
import SearchIcon from '@mui/icons-material/Search';
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import { v4 as uuidv4 } from 'uuid';

import { Product } from '../types/product'
import MapProducts from './MapProducts'
import { fetchAllProducts, sortByName, sortByPrice } from '../redux/reducers/productReducer';
import DividerComponent from './Divider'
import { fetchAllCategories } from '../redux/reducers/categoryReducers';

const Categories = () => {
    const dispatch = useAppDispatch()
    const products = useAppSelector(state => state.productReducer)
    const productsCategories = useAppSelector(state => state.categoryReducers)
    const [searchProduct, setSearchProduct] = useState('')
    const [searchParam] = useState(['title'])
    const [categoryDisplay, setcategoryDisplay] = useState<Product[]>([])
    const [renderDisplay, setRenderDisplay] = useState(false)
    const [catergoryTitle, setCategoryTitle] = useState('All Products')
        
    const sortName = () => {
        dispatch(sortByName('asc'))
    }

    const sortPrice = () => {
        dispatch(sortByPrice('asc'))
    }

    useEffect(() => {
        dispatch(fetchAllProducts())
    }, [dispatch])

    useEffect(() => {
        dispatch(fetchAllCategories())
    }, [dispatch])

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        setSearchProduct(e.target.value)
    }

    const renderProduct = (product: Product) => {
        return (
            <MapProducts
                key={uuidv4()}
                id={product.id}
                title={product.title}
                images={product.images}
                price={product.price}
                description={product.description}
                category={product.category}
            />
        )
    }

    //ref: https://www.freecodecamp.org/news/search-and-filter-component-in-reactjs/
    const searchProductFn = (products: any) => {
        return products.filter((product: { [x: string]: { toString: () => string; }; }) => {
            return searchParam.some((newItem) => {
                return (
                    product[newItem].toString().toLowerCase().indexOf(searchProduct.toLowerCase()) > -1
                );
            });
        });
    }

    const categoriesOnClick = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        const buttonValue = e.currentTarget.getAttribute("data-value")
        if (buttonValue) {
            setCategoryTitle(buttonValue)
        }
        const newArr: Product[] = []
        products.forEach(element => {
            const name = element.category.name
            if (name === buttonValue) {
                newArr.push(element)
            }
            return newArr
        });
        setcategoryDisplay(newArr)
        setRenderDisplay(true)
    }

    return (
        <>
            <Box display={'flex'} justifyContent='center' flexDirection={'column'} height={'100%'} >
                <Box marginTop={'20px'} sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                    <TextField onChange={(e) => handleChange(e)} value={searchProduct} placeholder='Search Product' color='primary' sx={{ width: '500px' }}
                        InputProps={{
                            endAdornment: (<InputAdornment position='start'>
                                <SearchIcon />
                            </InputAdornment>)
                        }} />
                    <FilterAltIcon sx={{ fontSize: '40px', marginLeft: '40px' }} />
                    <Box flexDirection={'row'} alignContent={'center'} >
                        <Button onClick={() => sortName()}>In Order</Button>
                        <Button onClick={() => sortPrice()}>By Price</Button>
                    </Box>
                </Box>
                <Box display={'flex'}
                    justifyContent={'space-evenly'}
                    alignSelf={'center'}
                    borderRadius={'10px'}
                    width={'100%'}
                    padding={'20px'}
                    marginTop={'40px'}
                    flexWrap={'wrap'}>
                    <Button sx={{bgcolor:'#FFC108'}} color='primary' variant='contained' >All Products</Button>
                    {productsCategories.map(name => (
                        <Button key={uuidv4()} data-value={name.name} onClick={categoriesOnClick} sx={{bgcolor:'#FFC108'}} color='primary' variant='contained' >{name.name}</Button>
                    ))
                    }
                </Box>
            </Box>
            <DividerComponent title={catergoryTitle} />
            <Grid container spacing={2} width={'auto'} margin={'30px'} marginTop={'10px'}  >
                {renderDisplay ? searchProductFn(categoryDisplay).map(renderProduct) : searchProductFn(products).map(renderProduct)}
            </Grid>
        </>
    )
}

export default Categories