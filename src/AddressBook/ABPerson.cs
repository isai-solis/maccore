// 
// ABPerson.cs: Implements the managed ABPerson
//
// Authors: Mono Team
//     
// Copyright (C) 2009 Novell, Inc
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
using System;
using System.Runtime.InteropServices;

using MonoMac.CoreFoundation;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace MonoMac.AddressBook {

	public enum ABPersonSortBy : uint {
		FirstName = 0,
		LastName  = 1,
	}

	public enum ABPersonCompositeNameFormat : uint {
		FirstNameFirst  = 0,
		LastNameFirst   = 1,
	}

	public enum ABPersonProperty {
		Address,
		Birthday,
		CreationDate,
		Date,
		Department,
		Email,
		FirstName,
		FirstNamePhonetic,
		InstantMessage,
		JobTitle,
		Kind,
		LastName,
		LastNamePhonetic,
		MiddleName,
		MiddleNamePhonetic,
		ModificationDate,
		Nickname,
		Note,
		Organization,
		Phone,
		Prefix,
		RelatedNames,
		Suffix,
		Url,
		SocialProfile
	}

	[Since (4,1)]
	public enum ABPersonImageFormat {
		Thumbnail = 0,
		OriginalSize = 2
	}
	
	static class ABPersonPropertyId {

		public static int Address {get; private set;}
		public static int Birthday {get; private set;}
		public static int CreationDate {get; private set;}
		public static int Date {get; private set;}
		public static int Department {get; private set;}
		public static int Email {get; private set;}
		public static int FirstName {get; private set;}
		public static int FirstNamePhonetic {get; private set;}
		public static int InstantMessage {get; private set;}
		public static int JobTitle {get; private set;}
		public static int Kind {get; private set;}
		public static int LastName {get; private set;}
		public static int LastNamePhonetic {get; private set;}
		public static int MiddleName {get; private set;}
		public static int MiddleNamePhonetic {get; private set;}
		public static int ModificationDate {get; private set;}
		public static int Nickname {get; private set;}
		public static int Note {get; private set;}
		public static int Organization {get; private set;}
		public static int Phone {get; private set;}
		public static int Prefix {get; private set;}
		public static int RelatedNames {get; private set;}
		public static int Suffix {get; private set;}
		public static int Url {get; private set;}
		public static int SocialProfile { get; private set; }
		
		static ABPersonPropertyId ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Address             = Dlfcn.GetInt32 (handle, "kABPersonAddressProperty");
				Birthday            = Dlfcn.GetInt32 (handle, "kABPersonBirthdayProperty");
				CreationDate        = Dlfcn.GetInt32 (handle, "kABPersonCreationDateProperty");
				Date                = Dlfcn.GetInt32 (handle, "kABPersonDateProperty");
				Department          = Dlfcn.GetInt32 (handle, "kABPersonDepartmentProperty");
				Email               = Dlfcn.GetInt32 (handle, "kABPersonEmailProperty");
				FirstName           = Dlfcn.GetInt32 (handle, "kABPersonFirstNameProperty");
				FirstNamePhonetic   = Dlfcn.GetInt32 (handle, "kABPersonFirstNamePhoneticProperty");
				InstantMessage      = Dlfcn.GetInt32 (handle, "kABPersonInstantMessageProperty");
				JobTitle            = Dlfcn.GetInt32 (handle, "kABPersonJobTitleProperty");
				Kind                = Dlfcn.GetInt32 (handle, "kABPersonKindProperty");
				LastName            = Dlfcn.GetInt32 (handle, "kABPersonLastNameProperty");
				LastNamePhonetic    = Dlfcn.GetInt32 (handle, "kABPersonLastNamePhoneticProperty");
				MiddleName          = Dlfcn.GetInt32 (handle, "kABPersonMiddleNameProperty");
				MiddleNamePhonetic  = Dlfcn.GetInt32 (handle, "kABPersonMiddleNamePhoneticProperty");
				ModificationDate    = Dlfcn.GetInt32 (handle, "kABPersonModificationDateProperty");
				Nickname            = Dlfcn.GetInt32 (handle, "kABPersonNicknameProperty");
				Note                = Dlfcn.GetInt32 (handle, "kABPersonNoteProperty");
				Organization        = Dlfcn.GetInt32 (handle, "kABPersonOrganizationProperty");
				Phone               = Dlfcn.GetInt32 (handle, "kABPersonPhoneProperty");
				Prefix              = Dlfcn.GetInt32 (handle, "kABPersonPrefixProperty");
				RelatedNames        = Dlfcn.GetInt32 (handle, "kABPersonRelatedNamesProperty");
				Suffix              = Dlfcn.GetInt32 (handle, "kABPersonSuffixProperty");
				Url                 = Dlfcn.GetInt32 (handle, "kABPersonURLProperty");
				SocialProfile       = Dlfcn.GetInt32 (handle, "kABPersonSocialProfileProperty");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}

		public static int ToId (ABPersonProperty property)
		{
			switch (property)
			{
				case ABPersonProperty.Address:            return Address;
				case ABPersonProperty.Birthday:           return Birthday;
				case ABPersonProperty.CreationDate:       return CreationDate;
				case ABPersonProperty.Date:               return Date;
				case ABPersonProperty.Department:         return Department;
				case ABPersonProperty.Email:              return Email;
				case ABPersonProperty.FirstName:          return FirstName;
				case ABPersonProperty.FirstNamePhonetic:  return FirstNamePhonetic;
				case ABPersonProperty.InstantMessage:     return InstantMessage;
				case ABPersonProperty.JobTitle:           return JobTitle;
				case ABPersonProperty.Kind:               return Kind;
				case ABPersonProperty.LastName:           return LastName;
				case ABPersonProperty.LastNamePhonetic:   return LastNamePhonetic;
				case ABPersonProperty.MiddleName:         return MiddleName;
				case ABPersonProperty.MiddleNamePhonetic: return MiddleNamePhonetic;
				case ABPersonProperty.ModificationDate:   return ModificationDate;
				case ABPersonProperty.Nickname:           return Nickname;
				case ABPersonProperty.Note:               return Note;
				case ABPersonProperty.Organization:       return Organization;
				case ABPersonProperty.Phone:              return Phone;
				case ABPersonProperty.Prefix:             return Prefix;
				case ABPersonProperty.RelatedNames:       return RelatedNames;
				case ABPersonProperty.Suffix:             return Suffix;
				case ABPersonProperty.Url:                return Url;
			}
			throw new NotSupportedException ("Invalid ABPersonProperty value: " + property);
		}

		public static ABPersonProperty ToPersonProperty (int id)
		{
			if (id == Address)            return ABPersonProperty.Address;
			if (id == Birthday)           return ABPersonProperty.Birthday;
			if (id == CreationDate)       return ABPersonProperty.CreationDate;
			if (id == Date)               return ABPersonProperty.Date;
			if (id == Department)         return ABPersonProperty.Department;
			if (id == Email)              return ABPersonProperty.Email;
			if (id == FirstName)          return ABPersonProperty.FirstName;
			if (id == FirstNamePhonetic)  return ABPersonProperty.FirstNamePhonetic;
			if (id == InstantMessage)     return ABPersonProperty.InstantMessage;
			if (id == JobTitle)           return ABPersonProperty.JobTitle;
			if (id == Kind)               return ABPersonProperty.Kind;
			if (id == LastName)           return ABPersonProperty.LastName;
			if (id == LastNamePhonetic)   return ABPersonProperty.LastNamePhonetic;
			if (id == MiddleName)         return ABPersonProperty.MiddleName;
			if (id == MiddleNamePhonetic) return ABPersonProperty.MiddleNamePhonetic;
			if (id == ModificationDate)   return ABPersonProperty.ModificationDate;
			if (id == Nickname)           return ABPersonProperty.Nickname;
			if (id == Note)               return ABPersonProperty.Note;
			if (id == Organization)       return ABPersonProperty.Organization;
			if (id == Phone)              return ABPersonProperty.Phone;
			if (id == Prefix)             return ABPersonProperty.Prefix;
			if (id == RelatedNames)       return ABPersonProperty.RelatedNames;
			if (id == Suffix)             return ABPersonProperty.Suffix;
			if (id == Url)                return ABPersonProperty.Url;
			throw new NotSupportedException ("Invalid ABPersonPropertyId value: " + id);
		}
	}

	public static class ABPersonAddressKey {

		public static NSString City {get; private set;}
		public static NSString Country {get; private set;}
		public static NSString CountryCode {get; private set;}
		public static NSString State {get; private set;}
		public static NSString Street {get; private set;}
		public static NSString Zip {get; private set;}

		static ABPersonAddressKey ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				City        = Dlfcn.GetStringConstant (handle, "kABPersonAddressCityKey");
				Country     = Dlfcn.GetStringConstant (handle, "kABPersonAddressCountryKey");
				CountryCode = Dlfcn.GetStringConstant (handle, "kABPersonAddressCountryCodeKey");
				State       = Dlfcn.GetStringConstant (handle, "kABPersonAddressStateKey");
				Street      = Dlfcn.GetStringConstant (handle, "kABPersonAddressStreetKey");
				Zip         = Dlfcn.GetStringConstant (handle, "kABPersonAddressZIPKey");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABPersonDateLabel {
		public static NSString Anniversary {get; private set;}

		static ABPersonDateLabel ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Anniversary = Dlfcn.GetStringConstant (handle, "kABPersonAnniversaryLabel");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public enum ABPersonKind {
		None,
		Organization,
		Person,
	}

	static class ABPersonKindId {
		public static NSNumber Organization {get; private set;}
		public static NSNumber Person {get; private set;}

		static ABPersonKindId ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Organization  = Dlfcn.GetNSNumber (handle, "kABPersonKindOrganization");
				Person        = Dlfcn.GetNSNumber (handle, "kABPersonKindPerson");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}

		public static ABPersonKind ToPersonKind (NSNumber value)
		{
			if (object.ReferenceEquals (Organization, value))
				return ABPersonKind.Organization;
			if (object.ReferenceEquals (Person, value))
				return ABPersonKind.Person;
			return ABPersonKind.None;
		}

		public static NSNumber FromPersonKind (ABPersonKind value)
		{
			switch (value) {
				case ABPersonKind.Organization: return Organization;
				case ABPersonKind.Person:       return Person;
			}
			return null;
		}
	}

	public static class ABPersonSocialProfile {
		static readonly NSString URLKey;
		static readonly NSString ServiceKey;
		static readonly NSString UsernameKey;
		static readonly NSString UserIdentifierKey;
		static readonly NSString ServiceTwitter;
		static readonly NSString ServiceGameCenter;
		static readonly NSString ServiceFacebook;
		static readonly NSString ServiceMyspace;
		static readonly NSString ServiceLinkedIn;
		static readonly NSString ServiceFlickr;

		static ABPersonSocialProfile ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				URLKey = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileURLKey");
				ServiceKey = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceKey");
				UsernameKey = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileUsernameKey");
				UserIdentifierKey = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileUserIdentifierKey");
				ServiceTwitter = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceTwitter");
				ServiceGameCenter = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceGameCenter");
				ServiceFacebook = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceFacebook");
				ServiceMyspace = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceMyspace");
				ServiceLinkedIn = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceLinkedIn");
				ServiceFlickr = Dlfcn.GetStringConstant (handle, "kABPersonSocialProfileServiceFlickr");
			} finally {
				Dlfcn.dlclose (handle);
			}
		}
	}
	
	public static class ABPersonPhoneLabel {
		public static NSString HomeFax {get; private set;}
		public static NSString iPhone {get; private set;}
		public static NSString Main {get; private set;}
		public static NSString Mobile {get; private set;}
		public static NSString Pager {get; private set;}
		public static NSString WorkFax {get; private set;}

		static ABPersonPhoneLabel ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				HomeFax = Dlfcn.GetStringConstant (handle, "kABPersonPhoneHomeFAXLabel");
				iPhone  = Dlfcn.GetStringConstant (handle, "kABPersonPhoneIPhoneLabel");
				Main    = Dlfcn.GetStringConstant (handle, "kABPersonPhoneMainLabel");
				Mobile  = Dlfcn.GetStringConstant (handle, "kABPersonPhoneMobileLabel");
				Pager   = Dlfcn.GetStringConstant (handle, "kABPersonPhonePagerLabel");
				WorkFax = Dlfcn.GetStringConstant (handle, "kABPersonPhoneWorkFAXLabel");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABPersonInstantMessageService {
		public static NSString Aim {get; private set;}
		public static NSString Icq {get; private set;}
		public static NSString Jabber {get; private set;}
		public static NSString Msn {get; private set;}
		public static NSString Yahoo {get; private set;}

		static ABPersonInstantMessageService ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Aim     = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceAIM");
				Icq     = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceICQ");
				Jabber  = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceJabber");
				Msn     = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceMSN");
				Yahoo   = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceYahoo");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABPersonInstantMessageKey {
		public static NSString Service {get; private set;}
		public static NSString Username {get; private set;}

		static ABPersonInstantMessageKey ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Service   = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageServiceKey");
				Username  = Dlfcn.GetStringConstant (handle, "kABPersonInstantMessageUsernameKey");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABPersonUrlLabel {
		public static NSString HomePage {get; private set;}

		static ABPersonUrlLabel ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				HomePage  = Dlfcn.GetStringConstant (handle, "kABPersonHomePageLabel");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABPersonRelatedNamesLabel {
		public static NSString Assistant {get; private set;}
		public static NSString Brother {get; private set;}
		public static NSString Child {get; private set;}
		public static NSString Father {get; private set;}
		public static NSString Friend {get; private set;}
		public static NSString Manager {get; private set;}
		public static NSString Mother {get; private set;}
		public static NSString Parent {get; private set;}
		public static NSString Partner {get; private set;}
		public static NSString Sister {get; private set;}
		public static NSString Spouse {get; private set;}

		static ABPersonRelatedNamesLabel ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Assistant = Dlfcn.GetStringConstant (handle, "kABPersonAssistantLabel");
				Brother   = Dlfcn.GetStringConstant (handle, "kABPersonBrotherLabel");
				Child     = Dlfcn.GetStringConstant (handle, "kABPersonChildLabel");
				Father    = Dlfcn.GetStringConstant (handle, "kABPersonFatherLabel");
				Friend    = Dlfcn.GetStringConstant (handle, "kABPersonFriendLabel");
				Manager   = Dlfcn.GetStringConstant (handle, "kABPersonMotherLabel");
				Mother    = Dlfcn.GetStringConstant (handle, "kABPersonManagerLabel");
				Parent    = Dlfcn.GetStringConstant (handle, "kABPersonParentLabel");
				Partner   = Dlfcn.GetStringConstant (handle, "kABPersonPartnerLabel");
				Sister    = Dlfcn.GetStringConstant (handle, "kABPersonSisterLabel");
				Spouse    = Dlfcn.GetStringConstant (handle, "kABPersonSpouseLabel");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public static class ABLabel {
		public static NSString Home {get; private set;}
		public static NSString Other {get; private set;}
		public static NSString Work {get; private set;}

		static ABLabel ()
		{
			InitConstants.Init ();
		}

		internal static void Init ()
		{
			var handle = Dlfcn.dlopen (Constants.AddressBookLibrary, 0);
			if (handle == IntPtr.Zero)
				return;
			try {
				Home      = Dlfcn.GetStringConstant (handle, "kABHomeLabel");
				Other     = Dlfcn.GetStringConstant (handle, "kABOtherLabel");
				Work      = Dlfcn.GetStringConstant (handle, "kABWorkLabel");
			}
			finally {
				Dlfcn.dlclose (handle);
			}
		}
	}

	public class ABPerson : ABRecord, IComparable, IComparable<ABPerson> {
		[DllImport (Constants.AddressBookLibrary)]
		extern static IntPtr ABPersonCreate ();

		public ABPerson ()
			: base (ABPersonCreate (), null)
		{
			InitConstants.Init ();
		}

		internal ABPerson (IntPtr handle, ABAddressBook addressbook)
			: base (CFObject.CFRetain (handle), addressbook)
		{
		}

		int IComparable.CompareTo (object o)
		{
			var other = o as ABPerson;
			if (other == null)
				throw new ArgumentException ("Can only compare to other ABPerson instances.", "o");
			return CompareTo (other);
		}

		public int CompareTo (ABPerson other)
		{
			return CompareTo (other, ABPersonSortBy.LastName);
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static int ABPersonComparePeopleByName (IntPtr person1, IntPtr person2, ABPersonSortBy ordering);
		public int CompareTo (ABPerson other, ABPersonSortBy ordering)
		{
			if (other == null)
				throw new ArgumentNullException ("other");
			if (ordering != ABPersonSortBy.FirstName && ordering != ABPersonSortBy.LastName)
				throw new ArgumentException ("Invalid ordering value: " + ordering, "ordering");
			return ABPersonComparePeopleByName (Handle, other.Handle, ordering);
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static IntPtr ABPersonCopyLocalizedPropertyName (int propertyId);
		public static string LocalizedPropertyName (ABPersonProperty property)
		{
			return Runtime.GetNSObject (ABPersonCopyLocalizedPropertyName (ABPersonPropertyId.ToId (property))).ToString ();
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static ABPropertyType ABPersonGetTypeOfProperty (int propertyId);
		public static ABPropertyType GetPropertyType (ABPersonProperty property)
		{
			return ABPersonGetTypeOfProperty (ABPersonPropertyId.ToId (property));
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static bool ABPersonSetImageData (IntPtr person, IntPtr imageData, out IntPtr error);
		[DllImport (Constants.AddressBookLibrary)]
		extern static IntPtr ABPersonCopyImageData (IntPtr person);

		public NSData Image {
			get {return (NSData) Runtime.GetNSObject (ABPersonCopyImageData (Handle));}
			set {
				IntPtr error;
				if (!ABPersonSetImageData (Handle, value == null ? IntPtr.Zero : value.Handle, out error))
					throw CFException.FromCFError (error);
			}
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static bool ABPersonHasImageData (IntPtr person);
		public bool HasImage {
			get {return ABPersonHasImageData (Handle);}
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static bool ABPersonRemoveImageData (IntPtr person, out IntPtr error);
		public void RemoveImage ()
		{
			IntPtr error;
			if (!ABPersonRemoveImageData (Handle, out error))
				throw CFException.FromCFError (error);
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static ABPersonCompositeNameFormat ABPersonGetCompositeNameFormat ();
		public static ABPersonCompositeNameFormat CompositeNameFormat {
			get {return ABPersonGetCompositeNameFormat ();}
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static ABPersonSortBy ABPersonGetSortOrdering ();
		public static ABPersonSortBy SortOrdering {
			get {return ABPersonGetSortOrdering ();}
		}

		public string FirstName {
			get {return PropertyToString (ABPersonPropertyId.FirstName);}
			set {SetValue (ABPersonPropertyId.FirstName, value);}
		}

		public string FirstNamePhonetic {
			get {return PropertyToString (ABPersonPropertyId.FirstNamePhonetic);}
			set {SetValue (ABPersonPropertyId.FirstNamePhonetic, value);}
		}

		public string LastName {
			get {return PropertyToString (ABPersonPropertyId.LastName);}
			set {SetValue (ABPersonPropertyId.LastName, value);}
		}

		public string LastNamePhonetic {
			get {return PropertyToString (ABPersonPropertyId.LastNamePhonetic);}
			set {SetValue (ABPersonPropertyId.LastNamePhonetic, value);}
		}

		public string MiddleName {
			get {return PropertyToString (ABPersonPropertyId.MiddleName);}
			set {SetValue (ABPersonPropertyId.MiddleName, value);}
		}

		public string MiddleNamePhonetic {
			get {return PropertyToString (ABPersonPropertyId.MiddleNamePhonetic);}
			set {SetValue (ABPersonPropertyId.MiddleNamePhonetic, value);}
		}

		public string Prefix {
			get {return PropertyToString (ABPersonPropertyId.Prefix);}
			set {SetValue (ABPersonPropertyId.Prefix, value);}
		}

		public string Suffix {
			get {return PropertyToString (ABPersonPropertyId.Suffix);}
			set {SetValue (ABPersonPropertyId.Suffix, value);}
		}

		public string Nickname {
			get {return PropertyToString (ABPersonPropertyId.Nickname);}
			set {SetValue (ABPersonPropertyId.Nickname, value);}
		}

		public string Organization {
			get {return PropertyToString (ABPersonPropertyId.Organization);}
			set {SetValue (ABPersonPropertyId.Organization, value);}
		}

		public string JobTitle {
			get {return PropertyToString (ABPersonPropertyId.JobTitle);}
			set {SetValue (ABPersonPropertyId.JobTitle, value);}
		}

		public string Department {
			get {return PropertyToString (ABPersonPropertyId.Department);}
			set {SetValue (ABPersonPropertyId.Department, value);}
		}

		internal static string ToString (IntPtr value)
		{
			if (value == IntPtr.Zero)
				return null;
			return Runtime.GetNSObject (value).ToString ();
		}

		internal static IntPtr ToIntPtr (string value)
		{
			if (value == null)
				return IntPtr.Zero;
			return new NSString (value).Handle;
		}

		public ABMultiValue<string> GetEmails ()
		{
			return CreateStringMultiValue (CopyValue (ABPersonPropertyId.Email));
		}

		static ABMultiValue<string> CreateStringMultiValue (IntPtr handle)
		{
			if (handle == IntPtr.Zero)
				return null;
			return new ABMultiValue<string> (handle, ToString, ToIntPtr);
		}

		public void SetEmails (ABMultiValue<string> value)
		{
			SetValue (ABPersonPropertyId.Email, value == null ? IntPtr.Zero : value.Handle);
		}

		public NSDate Birthday {
			get {return PropertyTo<NSDate> (ABPersonPropertyId.Birthday);}
			set {SetValue (ABPersonPropertyId.Birthday, value);}
		}

		public string Note {
			get {return PropertyToString (ABPersonPropertyId.Note);}
			set {SetValue (ABPersonPropertyId.Note, value);}
		}

		public NSDate CreationDate {
			get {return PropertyTo<NSDate> (ABPersonPropertyId.CreationDate);}
			set {SetValue (ABPersonPropertyId.CreationDate, value);}
		}

		public NSDate ModificationDate {
			get {return PropertyTo<NSDate> (ABPersonPropertyId.ModificationDate);}
			set {SetValue (ABPersonPropertyId.ModificationDate, value);}
		}

		public ABMultiValue<NSDictionary> GetAddresses ()
		{
			return CreateDictionaryMultiValue (CopyValue (ABPersonPropertyId.Address));
		}

		static ABMultiValue<NSDictionary> CreateDictionaryMultiValue (IntPtr handle)
		{
			if (handle == IntPtr.Zero)
				return null;
			return new ABMultiValue<NSDictionary> (handle);
		}

		public void SetAddresses (ABMultiValue<NSDictionary> value)
		{
			SetValue (ABPersonPropertyId.Address, value == null ? IntPtr.Zero : value.Handle);
		}

		public ABMultiValue<NSDate> GetDates ()
		{
			return CreateDateMultiValue (CopyValue (ABPersonPropertyId.Date));
		}

		static ABMultiValue<NSDate> CreateDateMultiValue (IntPtr handle)
		{
			if (handle == IntPtr.Zero)
				return null;
			return new ABMultiValue<NSDate> (handle);
		}

		public void SetDates (ABMultiValue<NSDate> value)
		{
			SetValue (ABPersonPropertyId.Date, value == null ? IntPtr.Zero : value.Handle);
		}

		public ABPersonKind PersonKind {
			get {return ABPersonKindId.ToPersonKind (PropertyTo<NSNumber> (ABPersonPropertyId.Kind));}
			set {SetValue (ABPersonPropertyId.Kind, ABPersonKindId.FromPersonKind (value));}
		}

		public ABMultiValue<string> GetPhones ()
		{
			return CreateStringMultiValue (CopyValue (ABPersonPropertyId.Phone));
		}

		public void SetPhones (ABMultiValue<string> value)
		{
			SetValue (ABPersonPropertyId.Phone, value == null ? IntPtr.Zero : value.Handle);
		}

		public ABMultiValue<NSDictionary> GetInstantMessages ()
		{
			return CreateDictionaryMultiValue (CopyValue (ABPersonPropertyId.InstantMessage));
		}

		public void SetInstantMessages (ABMultiValue<NSDictionary> value)
		{
			SetValue (ABPersonPropertyId.InstantMessage, value == null ? IntPtr.Zero : value.Handle);
		}

		public ABMultiValue<NSDictionary> GetSocialProfile ()
		{
			return CreateDictionaryMultiValue (CopyValue (ABPersonPropertyId.SocialProfile));
		}
		
		public void SetSocialProfile (ABMultiValue<NSDictionary> value)
		{
			SetValue (ABPersonPropertyId.SocialProfile, value == null ? IntPtr.Zero : value.Handle);
		}
		
		public ABMultiValue<string> GetUrls ()
		{
			return CreateStringMultiValue (CopyValue (ABPersonPropertyId.Url));
		}

		public void SetUrls (ABMultiValue<string> value)
		{
			SetValue (ABPersonPropertyId.Url, value == null ? IntPtr.Zero : value.Handle);
		}

		public ABMultiValue<string> GetRelatedNames ()
		{
			return CreateStringMultiValue (CopyValue (ABPersonPropertyId.RelatedNames));
		}

		public void SetRelatedNames (ABMultiValue<string> value)
		{
			SetValue (ABPersonPropertyId.RelatedNames, value == null ? IntPtr.Zero : value.Handle);
		}

		// TODO: Is there a better way to do this?
		public object GetProperty (ABPersonProperty property)
		{
			switch (property) {
				case ABPersonProperty.Address:             return GetAddresses ();
				case ABPersonProperty.Birthday:            return Birthday;
				case ABPersonProperty.CreationDate:        return CreationDate;
				case ABPersonProperty.Date:                return GetDates ();
				case ABPersonProperty.Department:          return Department;
				case ABPersonProperty.Email:               return GetEmails ();
				case ABPersonProperty.FirstName:           return FirstName;
				case ABPersonProperty.FirstNamePhonetic:   return FirstNamePhonetic;
				case ABPersonProperty.InstantMessage:      return GetInstantMessages ();
				case ABPersonProperty.JobTitle:            return JobTitle;
				case ABPersonProperty.Kind:                return PersonKind;
				case ABPersonProperty.LastName:            return LastName;
				case ABPersonProperty.LastNamePhonetic:    return LastNamePhonetic;
				case ABPersonProperty.MiddleName:          return MiddleName;
				case ABPersonProperty.MiddleNamePhonetic:  return MiddleNamePhonetic;
				case ABPersonProperty.ModificationDate:    return ModificationDate;
				case ABPersonProperty.Nickname:            return Nickname;
				case ABPersonProperty.Note:                return Note;
				case ABPersonProperty.Organization:        return Organization;
				case ABPersonProperty.Phone:               return GetPhones ();
				case ABPersonProperty.Prefix:              return Prefix;
				case ABPersonProperty.RelatedNames:        return GetRelatedNames ();
				case ABPersonProperty.Suffix:              return Suffix;
				case ABPersonProperty.Url:                 return GetUrls ();
				case ABPersonProperty.SocialProfile:       return GetSocialProfile ();
			}
			throw new ArgumentException ("Invalid property value: " + property);
		}

		[DllImport (Constants.AddressBookLibrary)]
		extern static IntPtr ABPersonCopyImageDataWithFormat (IntPtr handle, ABPersonImageFormat format);
		
		[Since (4,1)]
		NSData CopyImage (ABPersonImageFormat format)
		{
			return new NSData (ABPersonCopyImageDataWithFormat (Handle, format));
		}
	}
}

