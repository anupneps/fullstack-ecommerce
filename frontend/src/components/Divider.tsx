import { Typography } from '@mui/material'

export interface DividerProps {
    title?: string | undefined
}

const DividerComponent = ({ title }: DividerProps) => {
    return <Typography variant='h5' fontWeight={'bold'} marginLeft={'45px'} marginTop={'30px'}>{title}</Typography>
}

export default DividerComponent