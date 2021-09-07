import React from 'react';
import { pick } from 'lodash';

import PropTypes from 'prop-types';

const TextField = (props) => {

    const importedProps = pick(props, [
        'autoComplete',
        'autoFocus',
        'className',
        'defaultValue',
        'disabled',
        'name',
        'onBlur',
        'onChange',
        'onFocus',
        'placeholder',
        'className'
    ]);

    function changeValue(event)
    {
        props.onChange(event);
    }

    return (
        <>
            <input
                type="text"
                {...importedProps}
                onChange={changeValue}
                value={props.value}
            />
            <i className="material-icons pt-2">search</i>
        </>
    );
}

TextField.propTypes = {
    placeholder: PropTypes.string
}

TextField.defaultProps = {
    placeholder: 'Enter your text'
}

export default React.memo(TextField);