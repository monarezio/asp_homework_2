import * as React from "react";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface IState {}

interface IProps {
    is_showing: Boolean;
}

class Message extends React.Component<IProps, IState> { //TODO: Make nicer?
    render() {
        return <div className={'message ' + (!this.props.is_showing ? 'd-none' : '') }>
            <FontAwesomeIcon className='text-success' icon='check-circle'/>
            A question has been successfully sent!
            <a href='/' className='btn btn-primary'>Ok</a>
        </div>
    }
}

export default Message
