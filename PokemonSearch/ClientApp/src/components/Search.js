import PropTypes from 'prop-types';
import React, { useState, useEffect } from 'react'
import TextField from './TextField';


const Search = () => {

    const [searchText, setSearchText] = useState('');

    useEffect(() => {
        
    }, [searchText]);


    return (
        <div className="p-16 sm:p-24">
            <TextField value={searchText} onChange={(e) => setSearchText(e.target.value)} className=""/>
        </div>
    )
}

Search.propTypes = {

}

export default Search