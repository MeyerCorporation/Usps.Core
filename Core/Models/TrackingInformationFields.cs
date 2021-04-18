using System;
using System.Xml.Linq;

namespace MeyerCorp.Usps.Core.Models
{
	public class TrackingInformationFields : Model
	{
		public Error Error { get; set; }

		internal static TrackingInformationFields Parse(XElement e)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Guaranteed Delivery Date
		/// </summary>
		/// <remarks>Global Express Mail only:  certain countries provide a guarantee delivery</remarks>
		public DateTime? GuaranteedDeliveryDate { get; set; }

		/// <summary>
		/// Signifies if the mail piece is eSOF eligible.
		/// </summary>
		public bool? eSOFEligible { get; set; }

		/// <summary>
		/// Tracking Summary Information.
		/// </summary>
		public IENumerable<TrackSummary> TrackSummaries { get; set; }
//		Boolean




//TrackResponse / TrackInfo / TrackDetail

//Required once

//Tracking Detail Information.This group is repeatable.

//(Group)



//TrackResponse / TrackInfo / TrackDetail / EventTime

//Required

//The time of the event.

//String



//TrackResponse / TrackInfo / TrackDetail / EventDate

//Required

//The date of the event.

//String



//TrackResponse / TrackInfo / TrackDetail / Event

//Required

//The event type (e.g., Enroute).

//String




//TrackResponse / TrackInfo / TrackDetail / EventCity

//Required

//The city where the event occurred.

//String




//TrackResponse / TrackInfo / TrackDetail / EventState

//Required

//The state where the event occurred.

//String




//TrackResponse / TrackInfo / TrackDetail / EventZIPCode

//Required

//The ZIP Code of the event

//String




//TrackResponse / TrackInfo / TrackDetail / EventCountry

//Optional

//The country where the event occurred.

//String




//TrackResponse / TrackInfo / TrackDetail / FirmName

//Optional

//The company name if delivered to a company.

//String




//TrackResponse / TrackInfo / TrackDetail / Name

//Optional

//The name of the persons signing for delivery (if available).

//String




//TrackResponse / TrackInfo / TrackDetail / AuthorizedAgent

//Optional

//True/False field indicating the person signing as an Authorized Agent.

//String

//Enumeration =

//·         True

//·         False

//TrackResponse / TrackInfo / TrackDetail / EventCode

//Optional

//The event code

//String




//TrackResponse / TrackInfo / TrackDetail / ActionCode

//Optional

//The action code

//String




//TrackResponse / TrackInfo / TrackDetail / ReasonCode

//Optional

//The reason code

//String  TrackResults/ RequestSeqNumber

//Required max 1

//A unique identification number for a request.The same number that was provided in the request.

//For example: 122

//Integer



//TrackResults / TrackInfo ID

//Required max 10

//The tracking number ID submitted through the request

//For example: EA123456795US

//12887393000019

//String



//TrackResults / TrackInfo / AdditionalInfo

//Optional

//Additional package information

//String




//TrackResults / TrackInfo / ADPScripting

//Optional

//Additional ADP scripting specific to the ADP Type code

//String




//TrackResults / TrackInfo / ArchiveRestoreInfo

//Optional

//Information regarding availability of Restore service function

//For example Yes

//String



//TrackResults / TrackInfo / AssociatedLabel

//Optional

//Additional Label on the mail piece

//For example: EA123456785US

//This is not currently populated.

//String



//TrackResults / TrackInfo / CarrierRelease

//Optional

//True/False field indicating the item qualifies for the customer to electronically authorize shipment release.

//String



//TrackResults / TrackInfo / Class

//Optional

//Mail Class of the mail piece (human readable).  This will also include the service standard message if it exists. 

//No Default of False.

//String

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / ClassofMailCode

//Optional

//Mail Class of the mail piece (code).  For example:EX, PM, CP, IP

//String




//TrackResults / TrackInfo / DestinationCity

//Optional

//The destination city.For example: Rochester

//String




//TrackResults / TrackInfo / DestinationCountryCode

//Optional

//The destination country code.  For example:MX, CA

//String




//TrackResults / TrackInfo / DestinationState

//Optional

//The destination State.For example: NY

//String




//TrackResults / TrackInfo / DestinationZip

//Optional

//The destination ZIP code.  For example:20024

//String



//TrackResults / TrackInfo / EditedLabelID

//Optional

//Edited Label ID or Full Label ID.Used only when Source ID is IVR For example:EA123456795US

//String

//Enumerations=

//·         True

//·         False

//TrackResults / TrackInfo / EmailEnabled

//Optional

//Signifies if USPS Tracking by Email service is enabled.

//Boolean



//TrackResults / TrackInfo / EndOfDay

//Optional, used only when end of day condition is met

//Populated with the end of day time provided by TRP when TRP API indicates the window is “End of Day” or when the piece is eligible for the PTR default end of day.

//For example: by 5:00pm

//Note: an end of day scenario occurs when the TRP API response indicates a 0 length window.

//String



//TrackResults / TrackInfo / eSOFEligible

//Optional

//Signifies if the mailpiece is eSOF eligibile.

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / ExpectedDeliveryDate

//Optional

//Expected delivery date.For example:December 31, 2013

//String



//TrackResults / TrackInfo / ExpectedDeliveryTime

//Optional

//Expected Delivery Time.For example: 3:00 PM

//String




//TrackResults / TrackInfo / ExpectedDeliveryType

//Optional

//Populates “Expected Delivery by” if there is an EDD. For example: Expected Delivery by

//String




//TrackResults / TrackInfo / GuaranteedDeliveryDate

//Optional

//Guaranteed Delivery Date – Global Express Mail only: certain countries provide a guarantee delivery.

//For example: April 15, 2011 or 3 Business Days

//String



//TrackResults / TrackInfo / GuaranteedDeliveryTime

//Optional

//Guaranteed Delivery Time provided for Priority Mail Express.For example: 3:00 PM

//String




//TrackResults / TrackInfo / GuaranteedDeliveryType

//Optional

//Populates “Scheduled Delivery by” if there is a GDD. For example: Scheduled Delivery by

//String




//TrackResults / TrackInfo / GuaranteedDetails

//Optional

//Special messaging related to the guarantee. For example: “Loss Only Guarantee”

//String



//TrackResults / TrackInfo / ItemShape

//Optional

//Indicates the shape of the item.

//String

//Enumerations =

//·         Letter

//·         Flat

//·         Parcel

//·         Unknown

//TrackResults / TrackInfo / KahalaIndicator

//Optional




//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / MailTypeCode

//Optional




//String



//TrackResults / TrackInfo /  MPDATE

//Optional

//Internal date stamp.

//String



//TrackResults / TrackInfo / MPSUFFIX

//Optional

//Internal suffix.

//2010-03-30 19:30:48.224343

//Integer



//TrackResults / TrackInfo / OnTime

//Optional

//Field indicating if the item will be delivered on time as specified in the Expected or Guaranteed delivery date.

//String

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo /  OriginCity

//Optional

//The origin city.

//String



//TrackResults / TrackInfo / OriginCountryCode

//Optional

//The origin country code.

//String



//TrackResults / TrackInfo / OriginState

//Optional

//The origin state.

//String



//TrackResults / TrackInfo /  OriginZip

//Optional

//The origin ZIP code.

//String



//TrackResults / TrackInfo / PodEnabled

//Optional

//Signifies if Proof of Delivery service is enabled.

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / PredictedDeliveryDate

//Optional

//Predicted delivery date.December 30, 2013

//String



//TrackResults / TrackInfo / PredictedDeliveryTime

//Optional

//Predicted Delivery Time 3:00 PM or blank.

//String



//TrackResults / TrackInfo / PredictedDeliveryType

//Optional

//Populates “Expected Delivery ‘by or on’”, if the source of the PDD is TRP API.

//Populates “Expected Delivery on” if the source of the PDD is a PTR calculated date.

//For example: Expected Delivery by or Expected Delivery on

//String




//TrackResults / TrackInfoPredictedDeliverySource

//Optional

//States which system provided the Predicted Delivery prediction.

//TRP, AA

//String




//TrackResults / TrackInfo / PDWStart

//Optional

//Predicted Delivery Window start time in am/pm format.

//In an EndOfDay scenario, the PDWStart tag is null.

//11:00am

//For example: (null)

//String




//TrackResults / TrackInfo / PDWEnd

//Optional

//Predicted Delivery Window end time in am/pm format.

//In an EndOfDay scenario, the PDWEnd tag is null.

//1:00pm

//For example: (null)

//String




//TrackResults / TrackInfo / PurgeByDate

//Optional

//Contains the Purge By Date of the mail piece.

//Example: December 31, 2024

//String




//TrackResults / TrackInfo / RelatedRRID

//Optional

//The related label ID between a tracking barcode, the core product, and a PS3811, Green Card Return Reciept.This field can contain either the core product label ID or the Green Card label ID.There is only a one to one relationship.


//Core Product  ID: EA123456795US

//Or Green Card ID;

//9590940112345671234567

//String




//TrackResults / TrackInfo / RedeliveryEnabled

//Optional

//Field indicating if the item qualifies for redelivery.

//String

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / RestoreEnabled

//Optional

//Signifies if Restore tracking information service is enabled

//Values:

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / ReturnDateNotice

//Optional

//Field indicating the date the item will be Returned to Sender.

//String




//TrackResults / TrackInfo / PodEnabled

//Optional

//Signifies if Proof of Delivery service is enabled

//Boolean

//Enumerations=

//·         True

//·         False

//TrackResults / TrackInfo / TpodEnabled

//Optional

//Signifies if Tracking Proof of Delivery service is enabled

//Boolean

//Enumerations=

//·         True

//·         False

//TrackResults / TrackInfo / RRAMenabled

//Optional

//Signifies if RRAM service is enabled

//Boolean

//Enumerations=

//·         True

//·         False

//TrackResults / TrackInfo / RreEnabled

//Optional

//Signifies if Return Receipt Electronic service is enabled

//Boolean

//Enumerations=

//·         True

//·         False

//TrackResults / TrackInfo / Service

//Optional
//unbounded

//Additional services purchased

//String




//TrackResults / TrackInfo / ServiceTypeCode

//Optional
//max 1

//Service Type Code of the mail piece

//M, AD, VI, 03, 70, 716

//String




//TrackResults / TrackInfo / Status

//Optional

//For example: Delivered

//String




//TrackResults / TrackInfo / StatusCategory

//Optional

//For example: In Transit

//String




//TrackResults / TrackInfo / StatusSummary

//Optional

//Status summary

//For example: Your item was delivered at 12:55 pm on April 05, 2010 in FALMOUTH, MA 02540

//String




//TrackResults / TrackInfo / TABLECODE

//Optional

//Internal description of mail piece as it relates to PTR(live, history, or archived piece) T, H, A(CMC830 V3 – T is the only value defined)

//String




//TrackResults / TrackInfo / ValueofArticle<placeholder>

//Optional

//Value of Article for when the Source ID is PIN

//String




//TrackResults / TrackInfo / TrackSummary

//Optional
//max 1

//Tracking Summary Information.

//(Group)




//TrackResults / TrackInfo / TrackSummary / EventTime

//Optional

//The time of the event.

//String



//TrackResults / TrackInfo / TrackSummary / EventDate

//Optional

//The date of the event.

//String



//TrackResults / TrackInfo / TrackSummary / Event

//Optional

//The event type

//String




//TrackResults / TrackInfo / TrackSummary / EventCity

//Optional

//The city where the event occurred.

//String




//TrackResults / TrackInfo / TrackSummary / EventState

//Optional

//The state where the event occurred.

//String




//TrackResults / TrackInfo / TrackSummary / EventZIPCode

//Optional

//The ZIP Code of the event.

//String



//TrackResults / TrackInfo / TrackSummary / EventCountry

//Optional

//The country where the event occurred.

//String




//TrackResults / TrackInfo / TrackSummary / FirmName

//Optional

//The company name if delivered to a company.

//String




//TrackResults / TrackInfo / TrackSummary / Name

//Optional

//The first initial and last name of the person signing for delivery (if available).

//String




//TrackResults / TrackInfo / TrackSummary / EventCode

//Optional




//String




//TrackResults / TrackInfo / TrackSummary / ActionCode

//Optional
//max 1

 

//String




//TrackResults / TrackInfo / TrackSummary / ReasonCode

//Optional




//String




//TrackResults / TrackInfo / TrackSummary / GeoCertified

//Optional

//Only eligible to display with delivery(01) events.

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / TrackDetail

//Optional
//max 99

//Tracking Detail Information.This group is repeatable.

//(Group)




//TrackResults / TrackInfo / TrackDetail / DeliveryAttributeCode

//Optional

//Used to provide additional information regarding an event posted to a mail piece.

//String

//Enumerations =

//·         32

//TrackResults / TrackInfo / TrackDetail / EventTime

//Optional

//The time of the event.

//String



//TrackResults / TrackInfo / TrackDetail / EventDate

//Optional

//The date of the event.

//String



//TrackResults / TrackInfo / TrackDetail / Event

//Optional

//The event type.

//String




//TrackResults / TrackInfo / TrackDetail / EventCity

//Optional

//The city where the event occurred.

//String




//TrackResults / TrackInfo / TrackDetail / EventState

//Optional

//The state where the event occurred.

//String




//TrackResults / TrackInfo / TrackDetail / EventStatusCategory

//Optional

//The status of a posted event on a mail piece.

//String




//TrackResults / TrackInfo / TrackDetail / EventPartner

//Optional

//Stores the name of the shipping partner associated to a posted shipping partner event (80,81,82).

//String



//TrackResults / TrackInfo / TrackDetail / EventZIPCode

//Optional

//The ZIP Code of the event.

//String



//TrackResults / TrackInfo / TrackDetail / EventCountry

//Optional

//The country where the event occurred.

//String




//TrackResults / TrackInfo / TrackDetail / FirmName

//Optional

//The company name if delivered to a company.

//String




//TrackResults / TrackDetail / Name

//Optional

//The name of the persons signing for delivery (if available).

//String




//TrackResults / TrackInfo / TrackDetail / AuthorizedAgent

//Optional

//True/False field indicating the person signing as an Authorized Agent.

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / TrackDetail / EventCode

//Optional




//String




//TrackResults / TrackInfo / TrackDetail / ActionCode

//Optional
//max 1

 

//String




//TrackResults / TrackInfo / TrackDetail / ReasonCode

//Optional




//String




//TrackResults / TrackInfo / TrackDetail / GeoCertified

//Optional

//Only eligible to display with delivery(01) events.

//Boolean

//Enumerations =

//·         True

//·         False

//TrackResults / TrackInfo / Error

//Optional



//(Group)




//TrackResults / TrackInfo / Error / ErrorDescription

//Optional

//Descriptions of error message.

//Duplicate or 4 items were also tied to your 3849 ID but exceeded the maximum number of tracking number inquiries supported on this site.

//This 3849 ID was used on a large volume shipment and cannot be used for tracking on this site.

//String



//TrackResponse

//Required




//(Alias)

 }
}
