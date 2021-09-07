import clsx from 'clsx';
import React, { useState } from 'react';

import TextField  from './TextField';
import { AppService } from 'services'

const Layout = () => {

    const [error, setError] = useState(false);
    const [loading, setLoading] = useState(false);
    const [response, setResponse] = useState({});
    const [searchText, setSearchText] = useState('');
    

    const handleClick = () => {

        setError(false);
        setLoading(true);
        AppService.getSearchResults(searchText)
            .then(resp => {
                setResponse(resp);
                setLoading(false);
            })
            .catch(() => {
                setError(true);
                setLoading(false);
            });
    };

    return (
        <div className="flex flex-1 flex-col relative items-center justify-center">
            <div className="flex flex-col justify-center w-full max-w-md px-16 pt-20 sm:px-0">
                <div>
                    <div className="flex border border-gray-200 rounded-full p-4 shadow text-xl">
                        <TextField value={searchText} onChange={(e) => setSearchText(e.target.value)} required className="w-full outline-none px-3" />
                    </div>
                </div>

                <div className="mt-8 text-center">
                    <button className={clsx("mr-3 bg-gray-200 border border-gray-300 py-3 px-4 rounded hover:bg-gray-400 hover:border-gray-500", { 'cursor-not-allowed': loading || searchText === null || searchText === ''})} onClick={handleClick} disabled={loading || searchText === null || searchText === ''}>
                        Pokemon Search
                    </button>
                </div>
            </div>

            {loading && <div className="flex items-center justify-center pt-20">
                <div className="w-40 h-40 border-t-4 border-b-4 border-green-900 rounded-full animate-spin"></div>
                </div>
            }

            {response.name && <div className="flex justify-center w-full max-w-4xl px-16 pt-20 sm:px-0">
                <div className="flex bg-green-200 p-4 w-full">
                        <div className="flex justify-between">
                            <div className="text-green-600">
                                <p className="mb-2 font-bold">
                                    {response.name}
                                </p>
                                <p className="text-xs">
                                    {response.description}
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            }

            {error && <div className="flex justify-center w-full max-w-md px-16 pt-20 sm:px-0">
                    <div class="flex bg-red-200 p-4 w-full">
                        <div class="flex justify-between">
                            <div class="text-red-600">
                                <p class="mb-2 font-bold">
                                    Error
                                </p>
                                <p class="text-xs">
                                    Something went wrong, please try again...!
                                </p>
                            </div>
                        </div>
                    </div>  
                </div>
            }
        </div>
    );
}

Layout.propTypes = {

};

export default Layout